namespace CMSCore.Content.Repository.Interfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;

    public interface IUpdateContentRepository
    {
        Task UpdateFeed(UpdateFeedViewModel model, string entityId, string userId);
        Task UpdateFeedItem(UpdateFeedItemViewModel model, string entityId, string userId);
        Task UpdatePage(UpdatePageViewModel model, string entityId, string userId);
        Task UpdateTag(string tagName, string entityId, string userId);
    }
}