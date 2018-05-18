using System.Collections.Generic;
using CMSCore.Content.ViewModels;

namespace CMSCore.Content.Repository.Interfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.Models;

    public interface IReadContentRepository
    {
        IEnumerable<CommentViewModel> GetComments(string feedItemId);
        FeedViewModel GetFeed(string pageId);
        FeedItemViewModel GetFeedItem(string feedItemId);
        IEnumerable<FeedItemViewModel> GetFeedItemHistory(string feedItemId);
        IEnumerable<FeedItemPreviewViewModel> GetFeedItems(string feedId);
        PageViewModel GetPage(string pageId);
        IEnumerable<TagViewModel> GetTags(string feedItemId);
        IEnumerable<UserViewModel> GetUsers();
        IEnumerable<PageTreeViewModel> GetPageTree();
        PageViewModel GetPageByNormalizedName(string normalizedName);
        IEnumerable<PageViewModel> GetAllPages();
    }

    public interface IReadAsyncRepository
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
        Task<FeedItemViewModel> GetFeedItemViewModel(object feedItemObject);
    }
}