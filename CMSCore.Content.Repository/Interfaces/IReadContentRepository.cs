using System.Collections.Generic;
using CMSCore.Content.ViewModels;

namespace CMSCore.Content.Repository.Interfaces
{
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
}