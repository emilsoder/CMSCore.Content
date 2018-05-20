namespace CMSCore.Content.GrainInterfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public interface IRestoreContentGrain : IGrainWithStringKey

    {
        Task<GrainOperationResult> RestoreOnePageFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreOneFeedFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreOneFeedItemFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreFeedsFromRecycleBinByPageId(string pageId);
        Task<GrainOperationResult> RestoreFeedItemsFromRecycleBinByFeedId(string feedId);

        Task<GrainOperationResult> RestoreCommentsFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreTagsFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreTagsFromRecycleBinByFeedItemId(string feedItemId);
        Task<GrainOperationResult> RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId);
    }
}
//Task<GrainOperationResult> RestoreOnePageFromRecycleBinByEntityId(string entityId);
//Task<GrainOperationResult> RestoreOneFeedFromRecycleBinByEntityId(string entityId);
//Task<GrainOperationResult> RestoreOneFeedItemFromRecycleBinByEntityId(string entityId);
//Task<GrainOperationResult> RestoreFeedsFromRecycleBinByPageId(string pageId);
//Task<GrainOperationResult> RestoreFeedItemsFromRecycleBinByFeedId(string feedId);


//Task<GrainOperationResult> RestoreCommentsFromRecycleBinByEntityId(string entityId);
//Task<GrainOperationResult> RestoreTagsFromRecycleBinByEntityId(string entityId);
//Task<GrainOperationResult> RestoreTagsFromRecycleBinByFeedItemId(string feedItemId);
//Task<GrainOperationResult> RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId);