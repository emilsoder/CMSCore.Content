namespace CMSCore.Content.Grains
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public class ReadContentGrain : Grain, IReadContentGrain
    {
        private readonly IReadContentRepository _repository;

        public ReadContentGrain(IReadContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CommentViewModel>> GetComments(string feedItemId)
        {
            return await Task.FromResult(_repository.GetComments(feedItemId));
        }

        public async Task<FeedViewModel> GetFeed(string pageId)
        {
            return await Task.FromResult(_repository.GetFeed(pageId));
        }

        public async Task<FeedItemViewModel> GetFeedItem(string feedItemId)
        {
            return await Task.FromResult(_repository.GetFeedItem(feedItemId));
        }

        public async Task<IEnumerable<FeedItemViewModel>> GetFeedItemHistory(string feedItemId)
        {
            return await Task.FromResult(_repository.GetFeedItemHistory(feedItemId));
        }

        public async Task<IEnumerable<FeedItemPreviewViewModel>> GetFeedItems(string feedId)
        {
            return await Task.FromResult(_repository.GetFeedItems(feedId));
        }

        public async Task<PageViewModel> GetPage(string pageId)
        {
            return await Task.FromResult(_repository.GetPage(pageId));
        }

        public async Task<PageViewModel> GetPageByNormalizedName(string normalizedName)
        {
            return await Task.FromResult(_repository.GetPageByNormalizedName(normalizedName));
        }

        public async Task<IEnumerable<PageTreeViewModel>> GetPageTree()
        {
            return await Task.FromResult(_repository.GetPageTree());
        }

        public async Task<IEnumerable<TagViewModel>> GetTags(string feedItemId)
        {
            return await Task.FromResult(_repository.GetTags(feedItemId));
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            return await Task.FromResult(_repository.GetUsers());
        }
    }
}