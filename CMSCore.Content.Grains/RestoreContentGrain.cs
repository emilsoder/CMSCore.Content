namespace CMSCore.Content.Grains
{
    using System;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.Grains.Extensions;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public class RestoreContentGrain : Grain, IRestoreContentGrain
    {
        private readonly IRestoreContentRepository _repository;

        public RestoreContentGrain(IRestoreContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GrainOperationResult> RestoreCommentsFromRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.RestoreCommentsFromRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreCommentsFromRecycleBinByFeedItemId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.RestoreCommentsFromRecycleBinByFeedItemId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreFeedItemsFromRecycleBinByFeedId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.RestoreFeedItemsFromRecycleBinByFeedId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreFeedsFromRecycleBinByPageId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.RestoreFeedsFromRecycleBinByPageId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreOneFeedFromRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.RestoreOneFeedFromRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreOneFeedItemFromRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.RestoreOneFeedItemFromRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreOnePageFromRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.RestoreOnePageFromRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreTagsFromRecycleBinByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.RestoreTagsFromRecycleBinByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreTagsFromRecycleBinByFeedItemId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await _repository.RestoreTagsFromRecycleBinByFeedItemId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }
    }
}