using System.Threading.Tasks;
using CMSCore.Content.ViewModels;

namespace CMSCore.Content.Repository.Interfaces
{
    public interface IUpdateContentRepository
    {
        Task UpdateFeed(UpdateFeedViewModel model, string entityId, string userId);
        Task UpdateFeedItem(UpdateFeedItemViewModel model, string entityId);
        Task UpdatePage(UpdatePageViewModel model, string entityId, string userId);
        Task UpdateTag(string tagName, string entityId, string userId);
    }
}