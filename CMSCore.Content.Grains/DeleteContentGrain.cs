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

         public async Task<GrainOperationResult> DeleteCommentByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();
                await _repository.DeleteCommentByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteCommentsByFeedItemId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.DeleteCommentsByFeedItemId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteFeedByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.DeleteFeedByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteFeedByPageId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.DeleteFeedByPageId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteFeedItemsByFeedId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.DeleteFeedItemsByFeedId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteOneFeedItemByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.DeleteOneFeedItemByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeletePageAndRelatedEntities()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.DeletePageAndRelatedEntities(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteTagByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.DeleteTagByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> DeleteTagsByFeedItemId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.DeleteCommentByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }
    }
}