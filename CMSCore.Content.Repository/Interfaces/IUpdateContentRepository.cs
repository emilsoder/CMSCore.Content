namespace CMSCore.Content.Repository.Interfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;

    public interface IUpdateContentRepository
    {
        Task UpdateFeed(UpdateFeedViewModel model);
        Task UpdateFeedItem(UpdateFeedItemViewModel model);
        Task UpdatePage(UpdatePageViewModel model);
        Task UpdateTag(string tagName, string tagId);
    }
}