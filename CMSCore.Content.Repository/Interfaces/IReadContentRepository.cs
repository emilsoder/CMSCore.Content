namespace CMSCore.Content.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;

    public interface IReadContentRepository
    {
        IEnumerable<PageViewModel> GetAllPages();
        IEnumerable<CommentViewModel> GetComments(string feedItemId);
        FeedViewModel GetFeed(string pageId);
        FeedItemViewModel GetFeedItem(string feedItemId);
        IEnumerable<FeedItemViewModel> GetFeedItemHistory(string feedItemId);
        IEnumerable<FeedItemPreviewViewModel> GetFeedItems(string feedId);
        PageViewModel GetPage(string pageId);
        PageViewModel GetPageByNormalizedName(string normalizedName);
        IEnumerable<PageTreeViewModel> GetPageTree();
        IEnumerable<TagViewModel> GetTags(string feedItemId);
        IEnumerable<UserViewModel> GetUsers();
    }

    public interface IReadAsyncRepository
    {
        Task<IEnumerable<CommentViewModel>> GetComments(string feedItemId);
        Task<FeedViewModel> GetFeed(string pageId);
        Task<FeedItemViewModel> GetFeedItem(string feedItemId);
        Task<IEnumerable<FeedItemViewModel>> GetFeedItemHistory(string feedItemId);
        Task<IEnumerable<FeedItemPreviewViewModel>> GetFeedItems(string feedId);
        Task<FeedItemViewModel> GetFeedItemViewModel(object feedItemObject);
        Task<PageViewModel> GetPage(string pageId);
        Task<PageViewModel> GetPageByNormalizedName(string normalizedName);
        Task<IEnumerable<PageTreeViewModel>> GetPageTree();
        Task<IEnumerable<TagViewModel>> GetTags(string feedItemId);
        Task<IEnumerable<UserViewModel>> GetUsers();
    }
}