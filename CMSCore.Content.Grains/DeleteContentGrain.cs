namespace CMSCore.Content.Grains
{
    using System.Threading.Tasks;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using GrainInterfaces;
    using Orleans;

    public class DeleteContentGrain : Grain, IDeleteContentGrain
    {
        private readonly IDeleteContentRepository _repository;

        public DeleteContentGrain(IDeleteContentRepository repository)
        {
            _repository = repository;
        }

        private string GrainUserId => this.GetPrimaryKeyString();

        public async Task<GrainOperationResult> DeleteCommentByEntityId(string commentId)
        {
            return await _repository.DeleteCommentByEntityId(commentId).ExecuteTask();
        }

        public async Task<GrainOperationResult> DeleteTagByEntityId(string tagId)
        {
            return await _repository.DeleteTagByEntityId(tagId).ExecuteTask();
        }

        public async Task<GrainOperationResult> DeletePageAndRelatedEntities(string entityId)
        {
            return await _repository.DeletePageAndRelatedEntities(entityId).ExecuteTask();
        }

        public async Task<GrainOperationResult> DeleteFeedByPageId(string pageId)
        {
            return await _repository.DeleteFeedByPageId(pageId).ExecuteTask();
        }

        public async Task<GrainOperationResult> DeleteFeedByEntityId(string entityId)
        {
            return await _repository.DeleteFeedByEntityId(entityId).ExecuteTask();
        }

        public async Task<GrainOperationResult> DeleteFeedItemsByFeedId(string feedId)
        {
            return await _repository.DeleteFeedItemsByFeedId(feedId).ExecuteTask();
        }

        public async Task<GrainOperationResult> DeleteOneFeedItemByEntityId(string entityId)
        {
            return await _repository.DeleteOneFeedItemByEntityId(entityId).ExecuteTask();
        }

        public async Task<GrainOperationResult> DeleteTagsByFeedItemId(string feedItemId)
        {
            return await _repository.DeleteCommentByEntityId(feedItemId).ExecuteTask();
        }

        public async Task<GrainOperationResult> DeleteCommentsByFeedItemId(string feedItemId)
        {
            return await _repository.DeleteCommentsByFeedItemId(feedItemId).ExecuteTask();
        }
    }
}