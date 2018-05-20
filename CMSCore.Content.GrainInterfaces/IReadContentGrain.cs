namespace CMSCore.Content.GrainInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public interface IReadContentGrain : IGrainWithGuidKey
    {
        Task<IEnumerable<CommentViewModel>> GetComments(string feedItemId);
        Task<FeedViewModel> GetFeed(string pageId);
        Task<FeedItemViewModel> GetFeedItem(string feedItemId);
        Task<IEnumerable<FeedItemViewModel>> GetFeedItemHistory(string feedItemId);
        Task<IEnumerable<FeedItemPreviewViewModel>> GetFeedItems(string feedId);
        Task<PageViewModel> GetPage(string pageId);
        Task<IEnumerable<TagViewModel>> GetTags(string feedItemId);
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<IEnumerable<PageTreeViewModel>> GetPageTree();
        Task<PageViewModel> GetPageByNormalizedName(string normalizedName); 
    }
}