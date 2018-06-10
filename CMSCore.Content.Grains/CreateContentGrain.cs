namespace CMSCore.Content.Grains
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.Grains.Extensions;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public class CreateContentGrain : Grain, ICreateContentGrain
    {
        private readonly ICreateContentRepository _repository;

        public CreateContentGrain(ICreateContentRepository repository)
        {
            _repository = repository;
        }

        private string GrainUserId => this.GetPrimaryKeyString();

        public async Task<GrainOperationResult> CreateComment(CreateCommentViewModel model)
        {
            try
            {
                await _repository.CreateComment(model, GrainUserId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> CreateFeedItem(CreateFeedItemViewModel model)
        {
            try
            {
                await _repository.CreateFeedItem(model, GrainUserId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> CreatePage(CreatePageViewModel model)
        {
            try
            {
                await _repository.CreatePage(model, GrainUserId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> CreateFeed(CreateFeedViewModel model)
        {
            try
            {
                await _repository.CreateFeed(model, GrainUserId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> CreateTags(IList<string> tags, string feedItemId)
        {
            try
            {
                await _repository.CreateTags(tags, feedItemId, GrainUserId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        public async Task<GrainOperationResult> CreateUser(CreateUserViewModel model)
        {
            try
            {
                await _repository.CreateUser(model);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }
    }
}