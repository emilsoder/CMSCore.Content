namespace CMSCore.Content.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;

    public interface ICreateContentRepository
    {
        Task<string> CreateComment(CreateCommentViewModel model,  string userId);
        Task<string> CreateFeedItem(CreateFeedItemViewModel model, string userId);
        Task<string> CreateFeed(CreateFeedViewModel model, string userId);
        Task<string> CreatePage(CreatePageViewModel model, string userId, string feedName = null);
        Task CreateTags(IList<string> tags, string feedItemId, string userId);
        Task<string> CreateUser(CreateUserViewModel model);
    }
}