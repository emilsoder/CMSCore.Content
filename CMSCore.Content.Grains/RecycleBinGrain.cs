namespace CMSCore.Content.Grains
{
    using System.Threading.Tasks;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using GrainInterfaces;
    using Orleans;

    public class RecycleBinGrain : Grain, IRecycleBinGrain
    {
        private readonly IRecycleBinRepository _repository;

        public RecycleBinGrain(IRecycleBinRepository repository)
        {
            _repository = repository;
        }

        private string GrainUserId => this.GetPrimaryKeyString();
        

        public async Task<GrainOperationResult> MoveFeedItemToRecycleBinByEntityId(string feedItemId)
        {
            return await _repository.MoveFeedItemToRecycleBinByEntityId(feedItemId).ExecuteTask();
        }

        public async Task<GrainOperationResult> MoveFeedToRecycleBinByEntityId(string feedId)
        {
            return await _repository.MoveFeedToRecycleBinByEntityId(feedId).ExecuteTask();
        }

        public async Task<GrainOperationResult> MovePageToRecycleBinByEntityId(string pageId)
        {
            return await _repository.MovePageToRecycleBinByEntityId(pageId).ExecuteTask();
        }

        public async Task<GrainOperationResult> MoveTagToRecycleBinByEntityId(string tagId)
        {
            return await _repository.MoveTagToRecycleBinByEntityId(tagId).ExecuteTask();
        }

        public async Task<GrainOperationResult> MoveCommentToRecycleBinByEntityId(string commentId)
        {
            return await _repository.MoveCommentToRecycleBinByEntityId(commentId).ExecuteTask();
        }

        public async Task<GrainOperationResult> RestoreOnePageFromRecycleBinByEntityId(string entityId)
        {
            return await _repository.RestoreOnePageFromRecycleBinByEntityId(entityId).ExecuteTask();
        }

        public async Task<GrainOperationResult> RestoreOneFeedFromRecycleBinByEntityId(string entityId)
        {
            return await _repository.RestoreOneFeedFromRecycleBinByEntityId(entityId).ExecuteTask();
        }

        public async Task<GrainOperationResult> RestoreOneFeedItemFromRecycleBinByEntityId(string entityId)
        {
            return await _repository.RestoreOneFeedItemFromRecycleBinByEntityId(entityId).ExecuteTask();
        }

        public async Task<GrainOperationResult> RestoreFeedsFromRecycleBinByPageId(string pageId)
        {
            return await _repository.RestoreFeedsFromRecycleBinByPageId(pageId).ExecuteTask();
        }

        public async Task<GrainOperationResult> RestoreFeedItemsFromRecycleBinByFeedId(string feedId)
        {
            return await _repository.RestoreFeedItemsFromRecycleBinByFeedId(feedId).ExecuteTask();
        }

        public async Task<GrainOperationResult> RestoreCommentsFromRecycleBinByEntityId(string entityId)
        {
            return await _repository.RestoreCommentsFromRecycleBinByEntityId(entityId).ExecuteTask();
        }

        public async Task<GrainOperationResult> RestoreTagsFromRecycleBinByEntityId(string entityId)
        {
            return await _repository.RestoreTagsFromRecycleBinByEntityId(entityId).ExecuteTask();
        }

        public async Task<GrainOperationResult> RestoreTagsFromRecycleBinByFeedItemId(string feedItemId)
        {
            return await _repository.RestoreTagsFromRecycleBinByFeedItemId(feedItemId).ExecuteTask();
        }

        public async Task<GrainOperationResult> RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId)
        {
            return await _repository.RestoreCommentsFromRecycleBinByFeedItemId(feedItemId).ExecuteTask();
        }
    }
}