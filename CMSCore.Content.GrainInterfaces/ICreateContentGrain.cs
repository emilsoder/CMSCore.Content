namespace CMSCore.Content.GrainInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Messages;
    using Orleans;
  

    public interface ICreateContentGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> CreateComment(CreateCommentViewModel model);
        Task<GrainOperationResult> CreateFeedItem(CreateFeedItemViewModel model);
        Task<GrainOperationResult> CreatePage(CreatePageViewModel model);
        Task<GrainOperationResult> CreateFeed(CreateFeedViewModel model);
        Task<GrainOperationResult> CreateTags(IList<string> tags, string feedItemId);
        Task<GrainOperationResult> CreateUser(CreateUserViewModel model);
    }
}