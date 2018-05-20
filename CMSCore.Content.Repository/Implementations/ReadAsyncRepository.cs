namespace CMSCore.Content.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CMSCore.Content.Data;
    using CMSCore.Content.Models;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using Microsoft.EntityFrameworkCore;

    public class ReadAsyncRepository : IReadAsyncRepository
    {
        private readonly ContentDbContext _context;

        public ReadAsyncRepository(ContentDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<CommentViewModel>> GetComments(string feedItemId)
        {
            throw new NotImplementedException();
        }

        public Task<FeedViewModel> GetFeed(string pageId)
        {
            throw new NotImplementedException();
        }

        public Task<FeedItemViewModel> GetFeedItem(string feedItemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FeedItemViewModel>> GetFeedItemHistory(string feedItemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FeedItemPreviewViewModel>> GetFeedItems(string feedId)
        {
            throw new NotImplementedException();
        }

        public async Task<FeedItemViewModel> GetFeedItemViewModel(object feedItemObject)
        {
            if (!(feedItemObject is FeedItem))
            {
                return null;
            }

            return await GetFeedItemViewModel((FeedItem) feedItemObject);
        }

        public async Task<PageViewModel> GetPage(string pageId)
        {
            var pages = _context.Set<Page>().ActiveOnlyAsQueryable();
            if (pages == null || !pages.Any()) return null;

            var page = await pages.FirstOrDefaultAsync(x => x.EntityId == pageId);
            if (page == null) return null;

            var pageFeed = await GetFeed(pageId);

            return new PageViewModel
            {
                Content = page.Content,
                EntityId = page.EntityId,
                Date = page.Date,
                Modified = page.Modified,
                Name = page.Name,
                NormalizedName = page.NormalizedName,
                Feed = pageFeed
            };
        }

        public Task<PageViewModel> GetPageByNormalizedName(string normalizedName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PageTreeViewModel>> GetPageTree()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TagViewModel>> GetTags(string feedItemId)
        {
            var tags = _context.Set<Tag>()?.ActiveOnly()?.Where(x => x.FeedItemId == feedItemId);
            var vm = tags?.Select(x => new TagViewModel(x.Id, x.NormalizedName, x.Name));
            return Task.FromResult(vm);
        }

        public Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var users = _context.Set<User>().ActiveOnly();
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

            return Task.FromResult(vms);
        }

        private async Task<FeedItemViewModel> GetFeedItemViewModel(FeedItem feedItem)
        {
            var returnModel = new FeedItemViewModel();

            var feedItemTags = await GetTags(feedItem.EntityId);
            var comments = await GetComments(feedItem.EntityId);

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
    }
}