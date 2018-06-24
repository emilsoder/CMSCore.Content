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

 
        public async Task<GrainOperationResult> UpdateFeed(UpdateFeedViewModel model)
        {
            try
            {
                await _repository.UpdateFeed(model);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> UpdateFeedItem(UpdateFeedItemViewModel model)
        {
            try
            {
                await _repository.UpdateFeedItem(model);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> UpdatePage(UpdatePageViewModel model )
        {
            try
            {
                await _repository.UpdatePage(model);
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
                await _repository.UpdateTag(tagName, entityId );
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }
    }
}