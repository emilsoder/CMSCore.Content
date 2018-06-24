namespace CMSCore.Content.Grains
{
    using System;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.Grains.Extensions;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public class RecycleBinGrain : Grain, IRecycleBinGrain
    {
        private readonly IRecycleBinRepository _repository;

        public RecycleBinGrain(IRecycleBinRepository repository)
        {
            _repository = repository;
        }

        public async Task<GrainOperationResult> MoveCommentToRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.MoveCommentToRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }


        public async Task<GrainOperationResult> MoveFeedItemToRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.MoveFeedItemToRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> MoveFeedToRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.MoveFeedToRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> MovePageToRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.MovePageToRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> MoveTagToRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.MoveTagToRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }
    }
}