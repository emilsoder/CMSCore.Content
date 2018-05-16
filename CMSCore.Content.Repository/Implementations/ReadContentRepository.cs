using System;
using System.Collections.Generic;
using System.Linq;
using CMSCore.Content.Data;
using CMSCore.Content.Models;
using CMSCore.Content.Repository.Interfaces;
using CMSCore.Content.ViewModels;

namespace CMSCore.Content.Repository.Implementations
{
    public class ReadContentRepository : IReadContentRepository
    {
        private readonly ContentDbContext _context;

        public ReadContentRepository(ContentDbContext context)
        {
            _context = context;
        }

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
    public static class FilterExtensions
    {
        public static IEnumerable<TEntity> ActiveOnly<TEntity>(this IEnumerable<TEntity> set) where TEntity : EntityBase
        {
            return set.Where(DefaultPredicate<TEntity>());
        }

        public static Func<T, bool> DefaultPredicate<T>() where T : EntityBase
        {
            return arg => arg.Hidden == false && arg.IsActiveVersion == true && arg.MarkedToDelete == false;
        }
    }
}