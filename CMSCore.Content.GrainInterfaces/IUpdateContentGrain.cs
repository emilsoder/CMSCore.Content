namespace CMSCore.Content.GrainInterfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public interface IUpdateContentGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> UpdateFeed(UpdateFeedViewModel model, string entityId);
        Task<GrainOperationResult> UpdateFeedItem(UpdateFeedItemViewModel model, string entityId);
        Task<GrainOperationResult> UpdatePage(UpdatePageViewModel model, string entityId);
        Task<GrainOperationResult> UpdateTag(string tagName, string entityId);
    }
}