namespace CMSCore.Content.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;

    public interface ICreateContentRepository
    {
        Task<string> CreateComment(CreateCommentViewModel model );
        Task<string> CreateFeedItem(CreateFeedItemViewModel model);
        Task<string> CreateFeed(CreateFeedViewModel model);
        Task<string> CreatePage(CreatePageViewModel model,  string feedName = null);
        Task CreateTags(IList<string> tags, string feedItemId);
        Task<string> CreateUser(CreateUserViewModel model);
    }
}