using System.Collections.Generic;
using System.Threading.Tasks;
using CMSCore.Content.GrainInterfaces;
using CMSCore.Content.Repository.Interfaces;
using CMSCore.Content.ViewModels;
using Orleans;

namespace CMSCore.Content.Grains
{
    public class ReadContentGrain : Grain, IReadContentGrain
    {
        private readonly IReadContentRepository _repository;

        public ReadContentGrain(IReadContentRepository repository) => _repository = repository;

        public async Task<FeedViewModel> GetFeedByPageId(string pageId)
        {
            var id = this.GetPrimaryKeyString();

            return await _repository.GetFeed(id);
        }

        public async Task<FeedItemViewModel> GetFeedItemById(string feedItemId)
        {
            var id = this.GetPrimaryKeyString();

            return await _repository.GetFeedItem(id);
        }

        public async Task<IEnumerable<FeedItemPreviewViewModel>> FeedItemsByFeedId(string feedId)
        {
            var id = this.GetPrimaryKeyString();

            return await _repository.GetFeedItems(id);
        }

        public async Task<PageViewModel> FindPageById(string pageId)
        {
            var id = this.GetPrimaryKeyString();

            return await _repository.GetPage(id);
        }

        public async Task<PageViewModel> FindPageByNormalizedName()
        {
            var normalizedName = this.GetPrimaryKeyString();

            return await _repository.GetPageByNormalizedName(normalizedName);
        }

        public async Task<FeedItemViewModel> FindFeedItemByNormalizedName()
        {
            var normalizedName = this.GetPrimaryKeyString();

            return await _repository.GetFeedItemByNormalizedName(normalizedName);
        }

        public async Task<IEnumerable<PageTreeViewModel>> GetPageTree()
        {
            return await _repository.GetPageTree();
        }

        public async Task<IEnumerable<TagViewModel>> GetTagsByFeedItemId(string feedItemId)
        {
            var id = this.GetPrimaryKeyString();

            return await _repository.GetTags(id);
        }

        public async Task<IEnumerable<TagViewModel>> GetTags()
        {
            return await _repository.GetTags();
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            return await _repository.GetUsers();
        }
    }
}