using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSCore.Content.Data;
using CMSCore.Content.Models;
using CMSCore.Content.Models.Extensions;
using CMSCore.Content.ViewModels;

namespace CMSCore.Content.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly ContentDbContext _context;

        public ContentRepository(ContentDbContext context)
        {
            _context = context;
        }

        #region Create

        async Task<string> ICreateContentRepository.CreatePage(CreatePageViewModel model, string feedName)
        {
            var page = new Page(model.Name, model.FeedEnabled)
            {
                Content = model.Content,
                Name = model.Name,
                IsActiveVersion = true
            };
            if (model.FeedEnabled && !string.IsNullOrEmpty(feedName))
            {
                var feed = new Feed(page.EntityId, feedName);
                _context.Add(feed);
            }

            _context.Add(page);

            await _context.SaveChangesAsync();
            return page.EntityId;
        }

        async Task<string> ICreateContentRepository.CreateComment(CreateCommentViewModel model, string feedItemId)
        {
            var comment = new Comment(feedItemId, model.Text, model.FullName);

            _context.Add(comment);

            await _context.SaveChangesAsync();
            return comment.EntityId;
        }

        Task ICreateContentRepository.CreateTags(IList<string> tags, string feedItemId)
        {
            var tagsToCreate = tags.AsTagsEnumerable(feedItemId);

            _context.AddRange(tagsToCreate);

            return _context.SaveChangesAsync();
        }

        async Task<string> ICreateContentRepository.CreateFeedItem(CreateFeedItemViewModel model, string feedId)
        {
            var feedItem = new FeedItem(feedId, model.Title, model.Description, model.Content, model.CommentsEnabled);

            if (model.Tags != null && model.Tags.Any())
            {
                var tags = model.Tags.AsTagsEnumerable(feedItem.EntityId);
                _context.AddRange(tags);
            }

            _context.Add(feedItem);

            await _context.SaveChangesAsync();
            return feedItem.EntityId;
        }

        async Task<string> ICreateContentRepository.CreateUser(CreateUserViewModel model)
        {
            var user = new User(model.IdentityUserId)
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            _context.Add(user);

            await _context.SaveChangesAsync();
            return user.EntityId;
        }

        #endregion

        #region Update

        Task IUpdateContentRepository.UpdatePage(UpdatePageViewModel model, string entityId)
        {
            var foundActivePage =
                _context.Pages.FirstOrDefault(x => x.IsActiveVersion && x.EntityId == entityId);
            if (foundActivePage == null) return Task.FromException(new Exception("Page to update not found."));

            foundActivePage.IsActiveVersion = false;
            foundActivePage.Modified = DateTime.Now;
            _context.Update(foundActivePage);
            _context.SaveChanges();

            var newPage = foundActivePage;
            newPage.Id = Guid.NewGuid().ToString();
            newPage.IsActiveVersion = true;
            newPage.Name = model.Name;
            newPage.Version = GetNextVersion<Page>(foundActivePage.EntityId);
            newPage.Content = model.Content;
            newPage.FeedEnabled = model.FeedEnabled;
            _context.Add(newPage);

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateFeed(UpdateFeedViewModel model, string entityId)
        {
            var foundActiveFeed =
                _context.Feeds.FirstOrDefault(x => x.IsActiveVersion && x.EntityId == entityId);
            if (foundActiveFeed == null) return Task.FromException(new Exception("Feed to update not found."));

            foundActiveFeed.IsActiveVersion = false;
            foundActiveFeed.Modified = DateTime.Now;
            _context.Update(foundActiveFeed);
            _context.SaveChanges();

            var newFeed = foundActiveFeed;
            newFeed.Id = Guid.NewGuid().ToString();
            newFeed.IsActiveVersion = true;
            newFeed.Version = GetNextVersion<Feed>(foundActiveFeed.EntityId);
            newFeed.Name = model.Name;
            _context.Add(newFeed);

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateFeedItem(UpdateFeedItemViewModel model, string entityId)
        {
            var foundActiveFeed =
                _context.FeedItems.FirstOrDefault(x => x.IsActiveVersion && x.EntityId == entityId);

            if (foundActiveFeed == null) return Task.FromException(new Exception("FeedItem to update not found."));

            foundActiveFeed.IsActiveVersion = false;
            foundActiveFeed.Modified = DateTime.Now;
            _context.Update(foundActiveFeed);
            _context.SaveChanges();

            var newFeed = foundActiveFeed;
            newFeed.Id = Guid.NewGuid().ToString();
            newFeed.IsActiveVersion = true;
            newFeed.Version = GetNextVersion<FeedItem>(foundActiveFeed.EntityId);

            newFeed.CommentsEnabled = model.CommentsEnabled;
            newFeed.Content = model.Content;
            newFeed.Title = model.Title;
            newFeed.CommentsEnabled = model.CommentsEnabled;

            UpdateTagsIfChanged(newFeed.EntityId, model.Tags);

            _context.Add(newFeed);

            return _context.SaveChangesAsync();
        }

        private void UpdateTagsIfChanged(string feedItemId, IList<string> tags)
        {
            var feedItemTags = _context.Tags.Where(x => x.FeedItemId == feedItemId);
            _context.RemoveRange(feedItemTags);

            var tagsToAdd = tags.AsTagsEnumerable(feedItemId);
            _context.AddRange(tagsToAdd);
        }

        Task IUpdateContentRepository.UpdateTag(string newTagName, string tagId)
        {
            var activeTag = _context.Tags.FirstOrDefault(x => x.IsActiveVersion && x.EntityId == tagId);
            if (activeTag == null) return Task.FromException(new Exception("Tag to update not found."));

            activeTag.Name = newTagName;
            activeTag.Modified = DateTime.Now;
            _context.Update(activeTag);


            return _context.SaveChangesAsync();
        }

        private int GetNextVersion<T>(string entityId) where T : EntityBase
        {
            var set = _context.Set<T>().Where(x => x.EntityId == entityId).Select(x => x.Version);
            var orderedVersions = set.OrderByDescending(x => x);
            var v = orderedVersions.FirstOrDefault();
            return v + 1;
        }

        #endregion

        #region Delete

        // -------------

        Task IDeleteContentRepository.DeletePageAndRelatedEntities(string entityId, bool saveChanges)
        {
            if (!DeletePageAndRelatedEntities(entityId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeletePageAndRelatedEntities(string entityId)
        {
            var page = _context.Pages?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (page == null || !page.Any()) return false;

            DeleteFeedByPageId(entityId);
            _context.RemoveRange(page);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteFeedByPageId(string pageId, bool saveChanges)
        {
            if (!DeleteFeedByPageId(pageId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteFeedByPageId(string pageId)
        {
            var feedToDelete = _context.Feeds?.Where(x => x.PageId == pageId && x.MarkedToDelete);
            if (feedToDelete == null || !feedToDelete.Any()) return false;
            DeleteFeedItemsByFeedId(feedToDelete.First().EntityId);
            _context.RemoveRange(feedToDelete);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteFeedByEntityId(string entityId, bool saveChanges)
        {
            if (!DeleteFeedByEntityId(entityId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteFeedByEntityId(string entityId)
        {
            var feedToDelete = _context.Feeds?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feedToDelete == null || !feedToDelete.Any()) return false;
            DeleteFeedItemsByFeedId(entityId);
            _context.RemoveRange(feedToDelete);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteFeedItemsByFeedId(string feedId, bool saveChanges)
        {
            if (!DeleteFeedItemsByFeedId(feedId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteFeedItemsByFeedId(string feedId)
        {
            var feedItem = _context.FeedItems?.Where(x => x.FeedId == feedId && x.MarkedToDelete);
            if (feedItem == null || !feedItem.Any()) return false;

            var feedItemId = feedItem.First().EntityId;

            DeleteTagsByFeedItemId(feedItemId);
            DeleteCommentsByFeedItemId(feedItemId);
            _context.RemoveRange(feedItem);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteOneFeedItemByEntityId(string entityId, bool saveChanges)
        {
            if (!DeleteOneFeedItemByEntityId(entityId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteOneFeedItemByEntityId(string entityId)
        {
            var feedItem = _context.FeedItems?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feedItem == null || !feedItem.Any()) return false;

            DeleteTagsByFeedItemId(entityId);
            DeleteCommentsByFeedItemId(entityId);
            _context.RemoveRange(feedItem);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteTagsByFeedItemId(string feedItemId, bool saveChanges)
        {
            if (!DeleteTagsByFeedItemId(feedItemId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteTagsByFeedItemId(string feedItemId)
        {
            var tags = _context.Tags?.Where(x => x.FeedItemId == feedItemId);
            if (tags == null || !tags.Any()) return false;
            _context.RemoveRange(tags);
            return true;
        }

        // -------------
        Task IDeleteContentRepository.DeleteCommentsByFeedItemId(string feedItemId, bool saveChanges)
        {
            if (!DeleteCommentsByFeedItemId(feedItemId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteCommentsByFeedItemId(string feedItemId)
        {
            var comments = _context.Comments?.Where(x => x.FeedItemId == feedItemId);
            if (comments == null || !comments.Any()) return false;
            _context.RemoveRange(comments);
            return true;
        }

        // -------------
        Task IDeleteContentRepository.DeleteCommentByEntityId(string commentId)
        {
            if (!DeleteCommentByEntityId(commentId)) return Task.CompletedTask;

            return _context.SaveChangesAsync();
        }

        private bool DeleteCommentByEntityId(string commentId)
        {
            var comment = _context.Comments?.FirstOrDefault(x => x.EntityId == commentId);
            if (comment == null) return false;
            _context.Remove(comment);
            return true;
        }

        // -------------
        Task IDeleteContentRepository.DeleteTagByEntityId(string tagId)
        {
            if (!DeleteTagByEntityId(tagId)) return Task.CompletedTask;
            return _context.SaveChangesAsync();
        }

        private bool DeleteTagByEntityId(string tagId)
        {
            var tag = _context.Tags?.FirstOrDefault(x => x.EntityId == tagId);
            if (tag == null) return false;
            _context.Remove(tag);
            return true;
        }

        // -------------

        #endregion

        #region RecycleBinRepository

        Task IRecycleBinRepository.MovePageToRecycleBinByEntityId(string pageId)
        {
            MarkPageAsDeletedByEntityId(pageId);

            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveFeedToRecycleBinByEntityId(string feedId)
        {
            MarkFeedAsDeletedByEntityId(feedId);

            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveFeedItemToRecycleBinByEntityId(string feedItemId)
        {
            var feedItems = _context.FeedItems.Where(x => x.EntityId == feedItemId);

            if (!feedItems.Any()) return Task.FromException(new Exception("FeedItem to recycle not found"));
            MarkCommentsAsDeletedByFeedItemId(feedItemId);
            MarkTagsAsDeletedByFeedItemId(feedItemId);

            MarkAsDeletedAndUpdate(feedItems);
            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveCommentToRecycleBinByEntityId(string commentId)
        {
            var comments = _context.Comments?.Where(x => x.EntityId == commentId);

            if (comments == null || !comments.Any())
                return Task.FromException(new Exception("Comment to recycle not found"));

            MarkAsDeletedAndUpdate(comments);
            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveTagToRecycleBinByEntityId(string tagId)
        {
            var tags = _context.Tags?.Where(x => x.EntityId == tagId);

            if (tags == null || !tags.Any()) return Task.FromException(new Exception("Tag to recycle not found"));

            MarkAsDeletedAndUpdate(tags);
            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.RestoreFromRecycleBin<TEntityType>(string entityId)
        {
            var entitiesToRestore = _context.Set<TEntityType>()?.Where(x => x.EntityId == entityId);
            if (entitiesToRestore == null || !entitiesToRestore.Any()) return _context.SaveChangesAsync();
            foreach (var entity in entitiesToRestore)
            {
                entity.MarkedToDelete = false;
                _context.Update(entity);
            }

            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.RestoreOnePageFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var page = _context.Pages?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (page == null || !page.Any()) return Task.CompletedTask;
            foreach (var p in page)
            {
                p.MarkedToDelete = false;
                p.Modified = DateTime.Now;
                _context.Update(p);
            }

            ((IRecycleBinRepository) this).RestoreFeedsFromRecycleBinByPageId(entityId, false);


            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreOneFeedFromRecycleBinByEntityId(string entityId, bool saveChanges = true)
        {
            var feeds = _context.Feeds?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feeds == null || !feeds.Any()) return Task.CompletedTask;
            foreach (var feed in feeds)
            {
                feed.MarkedToDelete = false;
                feed.Modified = DateTime.Now;
                ((IRecycleBinRepository) this).RestoreFeedItemsFromRecycleBinByFeedId(entityId, false);
                _context.Update(feed);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreOneFeedItemFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var feedItems = _context.FeedItems?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feedItems == null || !feedItems.Any()) return Task.CompletedTask;
            foreach (var feedItem in feedItems)
            {
                feedItem.MarkedToDelete = false;
                feedItem.Modified = DateTime.Now;
                _context.Update(feedItem);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreFeedsFromRecycleBinByPageId(string pageId, bool saveChanges)
        {
            var feeds = _context.Feeds?.Where(x => x.PageId == pageId && x.MarkedToDelete);
            if (feeds == null || !feeds.Any()) return Task.CompletedTask;
            foreach (var feed in feeds)
            {
                feed.MarkedToDelete = false;
                feed.Modified = DateTime.Now;
                ((IRecycleBinRepository) this).RestoreFeedItemsFromRecycleBinByFeedId(feed.EntityId, false);
                _context.Update(feed);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreFeedItemsFromRecycleBinByFeedId(string feedId, bool saveChanges)
        {
            var feedItems = _context.FeedItems?.Where(x => x.FeedId == feedId && x.MarkedToDelete);
            if (feedItems == null || !feedItems.Any()) return Task.CompletedTask;
            foreach (var feedItem in feedItems)
            {
                feedItem.MarkedToDelete = false;
                feedItem.Modified = DateTime.Now;
                _context.Update(feedItem);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges)
        {
            var comments = _context.Comments?.Where(x => x.FeedItemId == feedItemId && x.MarkedToDelete);
            if (comments == null || !comments.Any()) return Task.CompletedTask;
            foreach (var comment in comments)
            {
                comment.MarkedToDelete = false;
                comment.Modified = DateTime.Now;
                _context.Update(comment);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreTagsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges)
        {
            var tags = _context.Tags?.Where(x => x.FeedItemId == feedItemId && x.MarkedToDelete);
            if (tags == null || !tags.Any()) return Task.CompletedTask;
            foreach (var tag in tags)
            {
                tag.MarkedToDelete = false;
                tag.Modified = DateTime.Now;
                _context.Update(tag);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreCommentsFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var comments = _context.Comments?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (comments == null || !comments.Any()) return Task.CompletedTask;
            foreach (var comment in comments)
            {
                comment.MarkedToDelete = false;
                comment.Modified = DateTime.Now;
                _context.Update(comment);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreTagsFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var tags = _context.Tags?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (tags == null || !tags.Any()) return Task.CompletedTask;
            foreach (var tag in tags)
            {
                tag.MarkedToDelete = false;
                tag.Modified = DateTime.Now;
                _context.Update(tag);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.EmptyRecycleBin<TEntityType>()
        {
            var set = _context.Set<TEntityType>()?.Where(x => x.MarkedToDelete);

            if (set == null || !set.Any())
                return Task.CompletedTask;

            _context.RemoveRange(set);

            return _context.SaveChangesAsync();
        }

        #region Private helpers

        private void MarkPageAsDeletedByEntityId(string entityId)
        {
            var pages = _context.Pages?.Where(x => x.EntityId == entityId);
            if (pages == null || !pages.Any()) return;
            MarkFeedAsDeletedByPageId(pages.First().EntityId);
            MarkAsDeletedAndUpdate(pages);
        }

        private void MarkFeedAsDeletedByPageId(string pageId)
        {
            var feed = _context.Feeds?.Where(x => x.PageId == pageId);
            if (feed == null || !feed.Any()) return;
            MarkFeedItemsAsDeletedByFeedId(feed.First().EntityId);
            MarkAsDeletedAndUpdate(feed);
        }

        private void MarkFeedAsDeletedByEntityId(string entityId)
        {
            var feed = _context.Feeds?.Where(x => x.EntityId == entityId);
            if (feed == null || !feed.Any()) return;
            MarkFeedItemsAsDeletedByFeedId(feed.First().EntityId);
            MarkAsDeletedAndUpdate(feed);
        }

        private void MarkFeedItemsAsDeletedByFeedId(string feedId)
        {
            var feedItems = _context.FeedItems?.Where(x => x.FeedId == feedId);

            if (feedItems == null || !feedItems.Any()) return;

            var ids = feedItems.Select(x => x.EntityId);
            if (ids.Any())
                foreach (var entityId in ids)
                {
                    MarkCommentsAsDeletedByFeedItemId(entityId);
                    MarkTagsAsDeletedByFeedItemId(entityId);
                }

            MarkAsDeletedAndUpdate(feedItems);
        }

        private void MarkCommentsAsDeletedByFeedItemId(string feedItemId)
        {
            var comments = _context.Comments?.Where(x => x.FeedItemId == feedItemId);
            if (comments != null && comments.Any()) MarkAsDeletedAndUpdate(comments);
        }

        private void MarkTagsAsDeletedByFeedItemId(string feedItemId)
        {
            var tags = _context.Tags?.Where(x => x.FeedItemId == feedItemId);
            if (tags != null && tags.Any()) MarkAsDeletedAndUpdate(tags);
        }

        private void MarkAsDeletedAndUpdate<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase
        {
            foreach (var entity in entities)
            {
                entity.MarkedToDelete = true;
                entity.Modified = DateTime.Now;
                _context.Update(entity);
            }
        }

        #endregion

        #endregion

        #region Read

        IEnumerable<PageTreeViewModel> IReadContentRepository.GetPageTree()
        {
            var pages = _context.Pages?.ToList();
            if (pages == null || !pages.Any()) return null;

            return pages.Select(x => new PageTreeViewModel
                {
                    Id = x.EntityId,
                    Date = x.Date,
                    Name = x.Name,
                    NormalizedName = x.NormalizedName
                })
                .ToList();
        }

        IEnumerable<PageViewModel> IReadContentRepository.GetAllPages()
        {
            var pages = _context.Pages?.ToList();

            return pages?.Select(x => ((IReadContentRepository) this).GetPage(x.EntityId)).ToList();
        }

        PageViewModel IReadContentRepository.GetPage(string pageId)
        {
            var page = _context.Pages?.ActiveOnly()?.FirstOrDefault(x => x.EntityId == pageId);
            if (page == null) return null;

            var pageFeed = ((IReadContentRepository) this).GetFeed(pageId);

            return new PageViewModel
            {
                Content = page.Content,
                Id = page.EntityId,
                Date = page.Date,
                Modified = page.Modified,
                Name = page.Name,
                NormalizedName = page.NormalizedName,
                Feed = pageFeed
            };
        }


        PageViewModel IReadContentRepository.GetPageByNormalizedName(string normalizedName)
        {
            var page = _context.Pages?.ActiveOnly()?.FirstOrDefault(x => x.NormalizedName == normalizedName);
            if (page == null) return null;

            var pageFeed = ((IReadContentRepository) this).GetFeed(page.EntityId);

            return new PageViewModel
            {
                Content = page.Content,
                Id = page.EntityId,
                Date = page.Date,
                Modified = page.Modified,
                Name = page.Name,
                NormalizedName = page.NormalizedName,
                Feed = pageFeed
            };
        }

        FeedViewModel IReadContentRepository.GetFeed(string pageId)
        {
            var returnModel = new FeedViewModel();

            var feed = _context.Feeds.ActiveOnly()?.SingleOrDefault(x => x.PageId == pageId);

            if (feed == null) return null;

            var feedItems = ((IReadContentRepository) this).GetFeedItems(feed.EntityId);

            returnModel.Id = feed.EntityId;
            returnModel.Date = feed.Date;
            returnModel.Modified = feed.Modified;
            returnModel.Name = feed.Name;
            returnModel.NormalizedName = feed.NormalizedName;
            returnModel.FeedItems = feedItems;

            return returnModel;
        }

        IEnumerable<FeedItemPreviewViewModel> IReadContentRepository.GetFeedItems(string feedId)
        {
            var returnModel = new List<FeedItemPreviewViewModel>();

            var feedItems = _context.FeedItems.ActiveOnly().Where(x => x.FeedId == feedId).ToList();

            foreach (var feedItem in feedItems)
            {
                var tags = ((IReadContentRepository) this).GetTags(feedItem.EntityId);

                returnModel.Add(new FeedItemPreviewViewModel
                {
                    Id = feedItem.Id,
                    Date = feedItem.Date,
                    Modified = feedItem.Modified,
                    Description = feedItem.Description,
                    NormalizedTitle = feedItem.NormalizedTitle,
                    Title = feedItem.Title,
                    Tags = tags
                });
            }

            return returnModel;
        }

        IEnumerable<FeedItemViewModel> IReadContentRepository.GetFeedItemHistory(string feedItemId)
        {
            var items = _context.FeedItems?.Where(x => x.EntityId == feedItemId).ToList();
            var vms = items?.Select(GetFeedItemViewModel);
            return vms?.ToList();
        }

        FeedItemViewModel IReadContentRepository.GetFeedItem(string feedItemId)
        {
            var feedItem = _context.FeedItems?.ToList().ActiveOnly()?.FirstOrDefault(x => x.EntityId == feedItemId);

            if (feedItem == null) return null;

            var returnModel = GetFeedItemViewModel(feedItem);
            return returnModel;
        }

        private FeedItemViewModel GetFeedItemViewModel(FeedItem feedItem)
        {
            var returnModel = new FeedItemViewModel();

            var feedItemTags = ((IReadContentRepository) this).GetTags(feedItem.EntityId);
            var comments = ((IReadContentRepository) this).GetComments(feedItem.EntityId);

            returnModel.Tags = feedItemTags;
            returnModel.Comments = comments;
            returnModel.NormalizedTitle = feedItem.NormalizedTitle;
            returnModel.Content = feedItem.Content;
            returnModel.CommentsEnabled = feedItem.CommentsEnabled;
            returnModel.Id = feedItem.EntityId;
            returnModel.Title = feedItem.Title;
            returnModel.Description = feedItem.Description;
            returnModel.FeedId = feedItem.FeedId;
            returnModel.Date = feedItem.Date;
            returnModel.Modified = feedItem.Modified;

            return returnModel;
        }

        IEnumerable<CommentViewModel> IReadContentRepository.GetComments(string feedItemId)
        {
            var tags = _context.Comments?.ActiveOnly()?.Where(x => x.FeedItemId == feedItemId);
            var vm = tags?.Select(x => new CommentViewModel
            {
                CommentId = x.EntityId,
                Date = x.Date,
                FullName = x.FullName,
                Text = x.Text
            });

            return vm?.ToList();
        }

        IEnumerable<TagViewModel> IReadContentRepository.GetTags(string feedItemId)
        {
            var tags = _context.Tags?.ActiveOnly()?.Where(x => x.FeedItemId == feedItemId);
            var vm = tags?.Select(x => new TagViewModel(x.Id, x.NormalizedName, x.Name));
            return vm?.ToList();
        }

        IEnumerable<UserViewModel> IReadContentRepository.GetUsers()
        {
            var users = _context.Users.ActiveOnly();
            var vms = users?.Select(x => new UserViewModel
            {
                Id = x.Id,
                Created = x.Date,
                Modified = x.Modified,
                Email = x.Email,
                FirstName = x.FirstName,
                IdentityUserId = x.IdentityUserId,
                LastName = x.LastName
            });

            return vms?.ToList();
        }

        #endregion
    }
}