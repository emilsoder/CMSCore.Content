namespace CMSCore.Content.Grains
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using GrainInterfaces;
    using Orleans;

    public class ReadContentGrain : Grain, IReadContentGrain
    {
        private readonly IReadContentRepository _repository;

        public ReadContentGrain(IReadContentRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<CommentViewModel>> GetComments(string feedItemId)
        {
            return Task.FromResult(_repository.GetComments(feedItemId));
        }

        public Task<FeedViewModel> GetFeed(string pageId)
        {
            return Task.FromResult(_repository.GetFeed(pageId));
        }

        public Task<FeedItemViewModel> GetFeedItem(string feedItemId)
        {
            return Task.FromResult(_repository.GetFeedItem(feedItemId));
        }

        public Task<IEnumerable<FeedItemViewModel>> GetFeedItemHistory(string feedItemId)
        {
            return Task.FromResult(_repository.GetFeedItemHistory(feedItemId));
        }

        public Task<IEnumerable<FeedItemPreviewViewModel>> GetFeedItems(string feedId)
        {
            return Task.FromResult(_repository.GetFeedItems(feedId));
        }

        public Task<PageViewModel> GetPage(string pageId)
        {
            return Task.FromResult(_repository.GetPage(pageId));
        }

        public Task<IEnumerable<TagViewModel>> GetTags(string feedItemId)
        {
            return Task.FromResult(_repository.GetTags(feedItemId));
        }

        public Task<IEnumerable<UserViewModel>> GetUsers()
        {
            return Task.FromResult(_repository.GetUsers());
        }

        public Task<IEnumerable<PageTreeViewModel>> GetPageTree()
        {
            return Task.FromResult(_repository.GetPageTree());
        }

        public Task<PageViewModel> GetPageByNormalizedName(string normalizedName)
        {
            return Task.FromResult(_repository.GetPageByNormalizedName(normalizedName));
        }
    }
}