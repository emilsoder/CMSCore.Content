namespace CMSCore.Content.GrainInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Messages;
    using Orleans;
   

    public interface IReadContentGrain : IGrainWithStringKey
    {
        Task<FeedViewModel> GetFeedByPageId(string pageId);
        Task<FeedItemViewModel> GetFeedItemById(string feedItemId);
        Task<PageViewModel> FindPageById(string pageId);
        Task<PageViewModel> FindPageByNormalizedName();
        Task<IEnumerable<PageTreeViewModel>> GetPageTree();
        Task<IEnumerable<TagViewModel>> GetTagsByFeedItemId(string feedItemId);
        Task<IEnumerable<TagViewModel>> GetTags();
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<IEnumerable<FeedItemPreviewViewModel>> FeedItemsByFeedId(string feedId);
        Task<FeedItemViewModel> FindFeedItemByNormalizedName();
    }
}