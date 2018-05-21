namespace CMSCore.Content.Grains
{
    using System;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.Grains.Extensions;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
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
            try
            {
                await _repository.DeleteCommentByEntityId(commentId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteCommentsByFeedItemId(string feedItemId)
        {
            try
            {
                await _repository.DeleteCommentsByFeedItemId(feedItemId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteFeedByEntityId(string entityId)
        {
            try
            {
                await _repository.DeleteFeedByEntityId(entityId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteFeedByPageId(string pageId)
        {
            try
            {
                await _repository.DeleteFeedByPageId(pageId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteFeedItemsByFeedId(string feedId)
        {
            try
            {
                await _repository.DeleteFeedItemsByFeedId(feedId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteOneFeedItemByEntityId(string entityId)
        {
            try
            {
                await _repository.DeleteOneFeedItemByEntityId(entityId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeletePageAndRelatedEntities(string entityId)
        {
            try
            {
                await _repository.DeletePageAndRelatedEntities(entityId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteTagByEntityId(string tagId)
        {
            try
            {
                await _repository.DeleteTagByEntityId(tagId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteTagsByFeedItemId(string feedItemId)
        {
            try
            {
                await _repository.DeleteCommentByEntityId(feedItemId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }
    }
}