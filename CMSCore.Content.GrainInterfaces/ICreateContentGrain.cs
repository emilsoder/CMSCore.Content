namespace CMSCore.Content.GrainInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public interface ICreateContentGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> CreateComment(CreateCommentViewModel model, string feedItemId);
        Task<GrainOperationResult> CreateFeedItem(CreateFeedItemViewModel model, string feedId);
        Task<GrainOperationResult> CreatePage(CreatePageViewModel model);
        Task<GrainOperationResult> CreateTags(IList<string> tags, string feedItemId);
        Task<GrainOperationResult> CreateUser(CreateUserViewModel model);
    }
}