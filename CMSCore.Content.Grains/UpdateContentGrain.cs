namespace CMSCore.Content.Grains
{
    using System.Threading.Tasks;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using GrainInterfaces;
    using Orleans;

    public class UpdateContentGrain : Grain, IUpdateContentGrain
    {
        private readonly IUpdateContentRepository _repository;
        private string GrainUserId => this.GetPrimaryKeyString();

        public UpdateContentGrain(IUpdateContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GrainOperationResult> UpdateFeed(UpdateFeedViewModel model, string entityId)
        {
            return await _repository.UpdateFeed(model, entityId, GrainUserId).ExecuteTask();
        }

        public async Task<GrainOperationResult> UpdateFeedItem(UpdateFeedItemViewModel model, string entityId)
        {
            return await _repository.UpdateFeedItem(model, entityId, GrainUserId).ExecuteTask();
        }

        public async Task<GrainOperationResult> UpdatePage(UpdatePageViewModel model, string entityId)
        {
            return await _repository.UpdatePage(model, entityId, GrainUserId).ExecuteTask();
        }

        public async Task<GrainOperationResult> UpdateTag(string tagName, string entityId)
        {
            return await _repository.UpdateTag(tagName, entityId, GrainUserId).ExecuteTask();
        }
    }
}