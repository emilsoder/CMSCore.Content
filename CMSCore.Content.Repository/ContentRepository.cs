using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSCore.Content.Data;
using CMSCore.Content.GrainInterfaces.Types;
using CMSCore.Content.Models;

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

        Task ICreateContentRepository.CreatePage(CreatePageViewModel model)
        {
            var page = new Page(model.Name, model.FeedEnabled)
            {
                Content = model.Content,
                Name = model.Name,
                IsActiveVersion = true
            };

            _context.Add(page);

            return _context.SaveChangesAsync();
        }

        Task ICreateContentRepository.CreateComment(CreateCommentViewModel model, string feedItemId)
        {
            var comment = new Comment(feedItemId, model.Text, model.FullName);

            _context.Add(comment);

            return _context.SaveChangesAsync();
        }

        Task ICreateContentRepository.CreateFeedItem(CreateFeedItemViewModel model, string feedId)
        {
            var feedItem = new FeedItem(feedId, model.Title, model.Description, model.Content, model.CommentsEnabled);

            _context.Add(feedItem);

            return _context.SaveChangesAsync();
        }

        Task ICreateContentRepository.CreateUser(CreateUserViewModel model)
        {
            var user = new User(model.IdentityUserId)
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            _context.Add(user);

            return _context.SaveChangesAsync();
        }

        #endregion

        #region Update

        Task IUpdateContentRepository.UpdatePage(UpdatePageViewModel model, string entityId)
        {
            var foundActivePage =
                _context.Pages.FirstOrDefault(x => x.IsActiveVersion == true && x.EntityId == entityId);
            if (foundActivePage == null)
            {
                return Task.FromException(new Exception("Page to update not found."));
            }

            foundActivePage.IsActiveVersion = false;
            foundActivePage.Modified = DateTime.Now;
            _context.Update(foundActivePage);

            var newPage = foundActivePage;
            newPage.Id = Guid.NewGuid().ToString();
            newPage.IsActiveVersion = true;
            newPage.Version = GetNextVersion<Page>(foundActivePage.EntityId);
            newPage.Content = model.Content;
            newPage.FeedEnabled = model.FeedEnabled;
            _context.Add(newPage);

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateFeed(UpdateFeedViewModel model, string entityId)
        {
            var foundActiveFeed =
                _context.Feeds.FirstOrDefault(x => x.IsActiveVersion == true && x.EntityId == entityId);
            if (foundActiveFeed == null)
            {
                return Task.FromException(new Exception("Feed to update not found."));
            }

            foundActiveFeed.IsActiveVersion = false;
            foundActiveFeed.Modified = DateTime.Now;
            _context.Update(foundActiveFeed);

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
                _context.FeedItems.FirstOrDefault(x => x.IsActiveVersion == true && x.EntityId == entityId);
            if (foundActiveFeed == null)
            {
                return Task.FromException(new Exception("FeedItem to update not found."));
            }

            foundActiveFeed.IsActiveVersion = false;
            foundActiveFeed.Modified = DateTime.Now;
            _context.Update(foundActiveFeed);

            var newFeed = foundActiveFeed;
            newFeed.Id = Guid.NewGuid().ToString();
            newFeed.IsActiveVersion = true;
            newFeed.Version = GetNextVersion<FeedItem>(foundActiveFeed.EntityId);

            newFeed.CommentsEnabled = model.CommentsEnabled;
            newFeed.Content = model.Content;
            newFeed.Title = model.Title;
            newFeed.CommentsEnabled = model.CommentsEnabled;

            _context.Add(newFeed);

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateTag(string tagName, string entityId)
        {
            var activeTag = _context.Tags.FirstOrDefault(x => x.IsActiveVersion == true && x.EntityId == entityId);
            if (activeTag == null)
            {
                return Task.FromException(new Exception("Tag to update not found."));
            }

            activeTag.IsActiveVersion = false;
            activeTag.Modified = DateTime.Now;
            _context.Update(activeTag);

            var tag = activeTag;
            tag.Id = Guid.NewGuid().ToString();
            tag.IsActiveVersion = true;
            tag.Version = GetNextVersion<Tag>(activeTag.EntityId);

            tag.Name = tagName;

            _context.Add(tag);

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

        Task IDeleteContentRepository.MovePageToRecycleBin(string pageId)
        {
            MarkPageAsDeleted(pageId);

            return _context.SaveChangesAsync();
        }

        Task IDeleteContentRepository.MoveFeedToRecycleBin(string feedId)
        {
            MarkFeedAsDeleted(feedId);

            return _context.SaveChangesAsync();
        }

        Task IDeleteContentRepository.MoveFeedItemToRecycleBin(string feedItemId)
        {
            var feedItems = _context.FeedItems.Where(x => x.EntityId == feedItemId);

            if (!feedItems.Any()) return Task.FromException(new Exception("FeedItem to recycle not found"));
            MarkCommentsAsDeleted(feedItemId);
            MarkTagsAsDeleted(feedItemId);

            MarkAsDeletedAndUpdate(feedItems);
            return _context.SaveChangesAsync();
        }

        public Task RestoreFromRecycleBin<TEntityType>(string entityId) where TEntityType : EntityBase
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

        public Task EmptyRecycleBin<TEntityType>() where TEntityType : EntityBase
        {
            return DeleteRecycledEntities<TEntityType>();
        }

        #region Private helpers
        private Task DeleteRecycledEntities<TEntityType>() where TEntityType : EntityBase
        {
            var set = _context.Set<TEntityType>()?.Where(x => x.MarkedToDelete == true);

            if (set == null || !set.Any())
                return Task.FromException(new Exception("No entities to delete"));

            _context.RemoveRange(set);

            return _context.SaveChangesAsync();
        }

        private void MarkPageAsDeleted(string entityId)
        {
            var pages = _context.Pages.Where(x => x.EntityId == entityId);
            if (!pages.Any()) return;
            MarkFeedAsDeleted(pages.First().EntityId);
            MarkAsDeletedAndUpdate(pages);
        }

        private void MarkFeedAsDeleted(string entityId)
        {
            var feed = _context.Feeds.Where(x => x.PageId == entityId);
            if (!feed.Any()) return;
            MarkFeedItemsAsDeleted(feed.First().EntityId);
            MarkAsDeletedAndUpdate(feed);
        }

        private void MarkFeedItemsAsDeleted(string feedId)
        {
            var feedItems = _context.FeedItems.Where(x => x.FeedId == feedId);

            if (!feedItems.Any()) return;

            var ids = feedItems?.Where(x => x.IsActiveVersion == true)?.Select(x => x.EntityId);
            if (ids.Any())
            {
                foreach (var entityId in ids)
                {
                    MarkCommentsAsDeleted(entityId);
                    MarkTagsAsDeleted(entityId);
                }
            }

            MarkAsDeletedAndUpdate(feedItems);
        }

        private void MarkCommentsAsDeleted(string feedItemId)
        {
            var comments = _context.Comments.Where(x => x.FeedItemId == feedItemId);
            if (comments.Any())
            {
                MarkAsDeletedAndUpdate(comments);
            }
        }

        private void MarkTagsAsDeleted(string feedItemId)
        {
            var tags = _context.Tags.Where(x => x.FeedItemId == feedItemId);
            if (tags.Any())
            {
                MarkAsDeletedAndUpdate(tags);
            }
        }

        private void MarkAsDeletedAndUpdate<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase
        {
            foreach (var entity in entities)
            {
                entity.MarkedToDelete = true;
                _context.Update(entity);
            }
        }

        #endregion

        #endregion

        #region Read

        PageViewModel IReadContentRepository.GetPage(string pageId)
        {
            var page = _context.Pages.ActiveOnly().FirstOrDefault(x => x.EntityId == pageId);
            var pageFeed = ((IReadContentRepository)this).GetFeed(pageId);

            return new PageViewModel()
            {
                Content = page.Content,
                Id = page.EntityId,
                Name = page.Name,
                NormalizedName = page.NormalizedName,
                Feed = pageFeed
            };
        }

        FeedViewModel IReadContentRepository.GetFeed(string pageId)
        {
            var returnModel = new FeedViewModel();

            var feed = _context.Feeds.ActiveOnly().SingleOrDefault(x => x.PageId == pageId);
            if (feed == null) return null;

            var feedItems = ((IReadContentRepository)this).GetFeedItems(feed.EntityId);

            returnModel.Id = feed.EntityId;
            returnModel.Name = feed.Name;
            returnModel.NormalizedName = feed.NormalizedName;
            returnModel.FeedItems = feedItems;

            return returnModel;
        }

        IEnumerable<FeedItemPreviewViewModel> IReadContentRepository.GetFeedItems(string feedId)
        {
            var returnModel = new List<FeedItemPreviewViewModel>();
            var feedItems = _context.FeedItems.ActiveOnly().Where(x => x.FeedId == feedId);
            foreach (var feedItem in feedItems)
            {
                var tags = ((IReadContentRepository)this).GetTags(feedItem.FeedId);

                returnModel.Add(new FeedItemPreviewViewModel()
                {
                    Id = feedItem.Id,
                    Created = feedItem.Date,
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
            var items = _context.FeedItems.Where(x => x.EntityId == feedItemId);
            var vms = items.Select(x => GetViewModel(x)).ToList();
            return vms;
        }

        FeedItemViewModel IReadContentRepository.GetFeedItem(string feedItemId)
        {
            var feedItem = _context.FeedItems.ActiveOnly().FirstOrDefault(x => x.EntityId == feedItemId);

            if (feedItem == null) return null;

            var returnModel = GetViewModel(feedItem);
            return returnModel;
        }

        private FeedItemViewModel GetViewModel(FeedItem feedItem)
        {
            var returnModel = new FeedItemViewModel();

            var feedItemTags = ((IReadContentRepository)this).GetTags(feedItem.EntityId);
            var comments = ((IReadContentRepository)this).GetComments(feedItem.EntityId);

            returnModel.Tags = feedItemTags;
            returnModel.Comments = comments;

            returnModel.Content = feedItem.Content;
            returnModel.CommentsEnabled = feedItem.CommentsEnabled;
            returnModel.Id = feedItem.EntityId;
            returnModel.Title = feedItem.Title;
            returnModel.Description = feedItem.Description;
            returnModel.FeedId = feedItem.FeedId;

            return returnModel;
        }

        IEnumerable<CommentViewModel> IReadContentRepository.GetComments(string feedItemId)
        {
            var tags = _context.Comments.ActiveOnly().Where(x => x.FeedItemId == feedItemId);
            var vm = tags.Select(x => new CommentViewModel()
            {
                CommentId = x.EntityId,
                FullName = x.FullName,
                Text = x.Text
            });

            return vm.ToList();
        }

        IEnumerable<TagViewModel> IReadContentRepository.GetTags(string feedItemId)
        {
            var tags = _context.Tags.ActiveOnly().Where(x => x.FeedItemId == feedItemId);
            var vm = tags.Select(x => new TagViewModel(x.Id, x.NormalizedName, x.Name));
            return vm.ToList();
        }

        IEnumerable<UserViewModel> IReadContentRepository.GetUsers()
        {
            var users = _context.Users.ActiveOnly();
            var vms = users.Select(x => new UserViewModel
            {
                Id = x.Id,
                Created = x.Date,
                Modified = x.Modified,
                Email = x.Email,
                FirstName = x.FirstName,
                IdentityUserId = x.IdentityUserId,
                LastName = x.LastName
            });

            return vms.ToList();
        }

        #endregion
    }
}
