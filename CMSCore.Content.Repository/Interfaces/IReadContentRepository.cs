namespace CMSCore.Content.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;

    public interface IReadContentRepository
    {
        Task<IEnumerable<PageViewModel>> GetAllPages();
        Task<FeedViewModel> GetFeed(string pageId);
        Task<FeedItemViewModel> GetFeedItem(string feedItemId);
        Task<IEnumerable<FeedItemPreviewViewModel>> GetFeedItems(string feedId);
        Task<PageViewModel> GetPage(string pageId);
        Task<PageViewModel> GetPageByNormalizedName(string normalizedName);
        Task<IEnumerable<PageTreeViewModel>> GetPageTree();
        Task<IEnumerable<TagViewModel>> GetTags(string feedItemId);
        Task<IEnumerable<TagViewModel>> GetTags();
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<FeedItemViewModel> GetFeedItemByNormalizedName(string normalizedName);
    }
}