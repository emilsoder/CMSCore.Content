namespace CMSCore.Content.Grains
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using GrainInterfaces;
    using Orleans;

    public class CreateContentGrain : Grain, ICreateContentGrain
    {
        private readonly ICreateContentRepository _repository;

        public CreateContentGrain(ICreateContentRepository repository)
        {
            _repository = repository;
        }

        private string GrainUserId => this.GetPrimaryKeyString();

        public async Task<GrainOperationResult> CreateComment(CreateCommentViewModel model, string feedItemId)
        {
            return await _repository.CreateComment(model, feedItemId, GrainUserId).ExecuteTask();
        }

        public async Task<GrainOperationResult> CreateFeedItem(CreateFeedItemViewModel model, string feedId)
        {
            return await _repository.CreateFeedItem(model, feedId, GrainUserId).ExecuteTask();
        }

        public async Task<GrainOperationResult> CreatePage(CreatePageViewModel model, string userId)
        {
            return await _repository.CreatePage(model, GrainUserId).ExecuteTask();
        }

        public async Task<GrainOperationResult> CreateTags(IList<string> tags, string feedItemId)
        {
            return await _repository.CreateTags(tags, feedItemId, GrainUserId).ExecuteTask();
        }

        public async Task<GrainOperationResult> CreateUser(CreateUserViewModel model)
        {
            return await _repository.CreateUser(model).ExecuteTask();
        }
    }
}