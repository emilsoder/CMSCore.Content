namespace CMSCore.Content.Repository.Interfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;

    public interface IUpdateContentRepository
    {
        Task UpdateFeed(UpdateFeedViewModel model, string userId);
        Task UpdateFeedItem(UpdateFeedItemViewModel model, string userId);
        Task UpdatePage(UpdatePageViewModel model, string userId);
        Task UpdateTag(string tagName, string entityId, string userId);
    }
}