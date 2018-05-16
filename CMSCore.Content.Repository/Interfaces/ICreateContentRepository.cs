using System.Collections.Generic;
using System.Threading.Tasks;
using CMSCore.Content.ViewModels;

namespace CMSCore.Content.Repository.Interfaces
{
    public interface ICreateContentRepository
    {
        Task<string> CreateComment(CreateCommentViewModel model, string feedItemId, string userId);
        Task<string> CreateFeedItem(CreateFeedItemViewModel model, string feedId, string userId);
        Task<string> CreatePage(CreatePageViewModel model, string userId, string feedName = null);
        Task<string> CreateUser(CreateUserViewModel model);
        Task CreateTags(IList<string> tags, string feedItemId, string userId);
    }
}