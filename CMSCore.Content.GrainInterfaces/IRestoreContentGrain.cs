namespace CMSCore.Content.GrainInterfaces
{
    using System.Threading.Tasks;
    using Messages;
    using Orleans;
 
    public interface IRestoreContentGrain : IGrainWithStringKey

    {
        Task<GrainOperationResult> RestoreCommentsFromRecycleBinByEntityId();
        Task<GrainOperationResult> RestoreCommentsFromRecycleBinByFeedItemId();
        Task<GrainOperationResult> RestoreFeedItemsFromRecycleBinByFeedId();
        Task<GrainOperationResult> RestoreFeedsFromRecycleBinByPageId();
        Task<GrainOperationResult> RestoreOneFeedFromRecycleBinByEntityId();
        Task<GrainOperationResult> RestoreOneFeedItemFromRecycleBinByEntityId();
        Task<GrainOperationResult> RestoreOnePageFromRecycleBinByEntityId();
        Task<GrainOperationResult> RestoreTagsFromRecycleBinByEntityId();
        Task<GrainOperationResult> RestoreTagsFromRecycleBinByFeedItemId();
    }
} 