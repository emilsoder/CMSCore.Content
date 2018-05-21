namespace CMSCore.Content.Grains
{
    using System;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.Grains.Extensions;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using Orleans;

    //  { try{return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };}catch (Exception ex){return ex.ResultFromException();}
    public class RestoreContentGrain : Grain, IRestoreContentGrain
    {
        private readonly IRestoreContentRepository _repository;

        public RestoreContentGrain(IRestoreContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GrainOperationResult> RestoreCommentsFromRecycleBinByEntityId(string entityId)
        {
            try
            {
                await _repository.RestoreCommentsFromRecycleBinByEntityId(entityId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId)
        {
            try
            {
                await _repository.RestoreCommentsFromRecycleBinByFeedItemId(feedItemId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreFeedItemsFromRecycleBinByFeedId(string feedId)
        {
            try
            {
                await _repository.RestoreFeedItemsFromRecycleBinByFeedId(feedId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreFeedsFromRecycleBinByPageId(string pageId)
        {
            try
            {
                await _repository.RestoreFeedsFromRecycleBinByPageId(pageId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreOneFeedFromRecycleBinByEntityId(string entityId)
        {
            try
            {
                await _repository.RestoreOneFeedFromRecycleBinByEntityId(entityId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreOneFeedItemFromRecycleBinByEntityId(string entityId)
        {
            try
            {
                await _repository.RestoreOneFeedItemFromRecycleBinByEntityId(entityId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreOnePageFromRecycleBinByEntityId(string entityId)
        {
            try
            {
                await _repository.RestoreOnePageFromRecycleBinByEntityId(entityId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreTagsFromRecycleBinByEntityId(string entityId)
        {
            try
            {
                await _repository.RestoreTagsFromRecycleBinByEntityId(entityId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> RestoreTagsFromRecycleBinByFeedItemId(string feedItemId)
        {
            try
            {
                await _repository.RestoreTagsFromRecycleBinByFeedItemId(feedItemId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }
    }

    public class RecycleBinGrain : Grain, IRecycleBinGrain
    {
        private readonly IRecycleBinRepository _repository;

        public RecycleBinGrain(IRecycleBinRepository repository)
        {
            _repository = repository;
        }

        private string GrainUserId => this.GetPrimaryKeyString();

        public async Task<GrainOperationResult> MoveCommentToRecycleBinByEntityId(string commentId)
        {
            try
            {
                await _repository.MoveCommentToRecycleBinByEntityId(commentId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }


        public async Task<GrainOperationResult> MoveFeedItemToRecycleBinByEntityId(string feedItemId)
        {
            try
            {
                await _repository.MoveFeedItemToRecycleBinByEntityId(feedItemId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> MoveFeedToRecycleBinByEntityId(string feedId)
        {
            try
            {
                await _repository.MoveFeedToRecycleBinByEntityId(feedId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> MovePageToRecycleBinByEntityId(string pageId)
        {
            try
            {
                await _repository.MovePageToRecycleBinByEntityId(pageId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> MoveTagToRecycleBinByEntityId(string tagId)
        {
            try
            {
                await _repository.MoveTagToRecycleBinByEntityId(tagId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }
    }
}