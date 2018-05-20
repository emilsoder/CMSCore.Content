namespace CMSCore.Content.Repository.Interfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.Models;

    public interface IRecycleBinRepository
    {
        Task EmptyRecycleBin<TEntityType>() where TEntityType : EntityBase;
        Task MoveCommentToRecycleBinByEntityId(string commentId);

        Task MoveFeedItemToRecycleBinByEntityId(string feedItemId);
        Task MoveFeedToRecycleBinByEntityId(string feedId);
        Task MovePageToRecycleBinByEntityId(string pageId);
        Task MoveTagToRecycleBinByEntityId(string tagId);


    }

    public interface IRestoreContentRepository
    {

        Task RestoreCommentsFromRecycleBinByEntityId(string entityId, bool saveChanges = true);
        Task RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges = true);
        Task RestoreFeedItemsFromRecycleBinByFeedId(string feedId, bool saveChanges = true);
        Task RestoreFeedsFromRecycleBinByPageId(string pageId, bool saveChanges = true);

        Task RestoreFromRecycleBin<TEntityType>(string entityId) where TEntityType : EntityBase;
        Task RestoreOneFeedFromRecycleBinByEntityId(string entityId, bool saveChanges = true);
        Task RestoreOneFeedItemFromRecycleBinByEntityId(string entityId, bool saveChanges = true);

        Task RestoreOnePageFromRecycleBinByEntityId(string entityId, bool saveChanges = true);
        Task RestoreTagsFromRecycleBinByEntityId(string entityId, bool saveChanges = true);
        Task RestoreTagsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges = true);
    }
}