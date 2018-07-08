namespace CMSCore.Content.Grains.Repos.Interfaces
{
    using System.Threading.Tasks;
    using GrainInterfaces.Messages;

    public interface IUpdateContentRepository
    {
        Task UpdateFeed(UpdateFeedViewModel model);
        Task UpdateFeedItem(UpdateFeedItemViewModel model);
        Task UpdatePage(UpdatePageViewModel model);
        Task UpdateTag(string tagName, string tagId);
    }
}