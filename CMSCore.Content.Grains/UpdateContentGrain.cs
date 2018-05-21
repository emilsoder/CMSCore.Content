namespace CMSCore.Content.Grains
{
    using System;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.Grains.Extensions;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public class UpdateContentGrain : Grain, IUpdateContentGrain
    {
        private readonly IUpdateContentRepository _repository;

        public UpdateContentGrain(IUpdateContentRepository repository)
        {
            _repository = repository;
        }

        private string GrainUserId => this.GetPrimaryKeyString();

        public async Task<GrainOperationResult> UpdateFeed(UpdateFeedViewModel model, string entityId)
        {
            try
            {
                await _repository.UpdateFeed(model, entityId, GrainUserId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> UpdateFeedItem(UpdateFeedItemViewModel model, string entityId)
        {
            try
            {
                await _repository.UpdateFeedItem(model, entityId, GrainUserId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> UpdatePage(UpdatePageViewModel model, string entityId)
        {
            try
            {
                await _repository.UpdatePage(model, entityId, GrainUserId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> UpdateTag(string tagName, string entityId)
        {
            try
            {
                await _repository.UpdateTag(tagName, entityId, GrainUserId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }
    }
}