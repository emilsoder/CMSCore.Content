using System.Collections.Generic;
using System.Threading.Tasks;
using CMSCore.Content.Models;
using CMSCore.Content.ViewModels;

namespace CMSCore.Content.Repository
{
    public interface IContentRepository :
        IReadContentRepository,
        ICreateContentRepository,
        IUpdateContentRepository,
        IRecycleBinRepository,
        IDeleteContentRepository
    {
    }

    public interface IRecycleBinRepository
    {
        Task EmptyRecycleBin<TEntityType>() where TEntityType : EntityBase;

        Task MoveFeedItemToRecycleBinByEntityId(string feedItemId);
        Task MoveFeedToRecycleBinByEntityId(string feedId);
        Task MovePageToRecycleBinByEntityId(string pageId);
        Task MoveTagToRecycleBinByEntityId(string tagId);
        Task MoveCommentToRecycleBinByEntityId(string commentId);

        Task RestoreFromRecycleBin<TEntityType>(string entityId) where TEntityType : EntityBase;

        Task RestoreOnePageFromRecycleBinByEntityId(string entityId, bool saveChanges = true);
        Task RestoreOneFeedFromRecycleBinByEntityId(string entityId, bool saveChanges = true);
        Task RestoreOneFeedItemFromRecycleBinByEntityId(string entityId, bool saveChanges = true);
        Task RestoreFeedsFromRecycleBinByPageId(string pageId, bool saveChanges = true);
        Task RestoreFeedItemsFromRecycleBinByFeedId(string feedId, bool saveChanges = true);


        Task RestoreCommentsFromRecycleBinByEntityId(string entityId, bool saveChanges = true);
        Task RestoreTagsFromRecycleBinByEntityId(string entityId, bool saveChanges = true);
        Task RestoreTagsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges = true);
        Task RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges = true);
    }

    public interface IDeleteContentRepository
    {
        Task DeleteCommentByEntityId(string commentId);
        Task DeleteTagByEntityId(string tagId);
        Task DeletePageAndRelatedEntities(string entityId, bool saveChanges = true);
        Task DeleteFeedByPageId(string pageId, bool saveChanges = true);
        Task DeleteFeedByEntityId(string entityId, bool saveChanges = true);
        Task DeleteFeedItemsByFeedId(string feedId, bool saveChanges = true);
        Task DeleteOneFeedItemByEntityId(string entityId, bool saveChanges = true);
        Task DeleteTagsByFeedItemId(string feedItemId, bool saveChanges = true);
        Task DeleteCommentsByFeedItemId(string feedItemId, bool saveChanges = true);
    }

    public interface ICreateContentRepository
    {
        Task<string> CreateComment(CreateCommentViewModel model, string feedItemId);
        Task<string> CreateFeedItem(CreateFeedItemViewModel model, string feedId);
        Task<string> CreatePage(CreatePageViewModel model, string feedName = "");
        Task<string> CreateUser(CreateUserViewModel model);
        Task CreateTags(IList<string> tags, string feedItemId);
    }

    public interface IUpdateContentRepository
    {
        Task UpdateFeed(UpdateFeedViewModel model, string entityId);
        Task UpdateFeedItem(UpdateFeedItemViewModel model, string entityId);
        Task UpdatePage(UpdatePageViewModel model, string entityId);
        Task UpdateTag(string tagName, string entityId);
    }

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