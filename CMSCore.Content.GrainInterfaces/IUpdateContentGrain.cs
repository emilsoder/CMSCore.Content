namespace CMSCore.Content.GrainInterfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public interface IUpdateContentGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> UpdateFeed(UpdateFeedViewModel model );
        Task<GrainOperationResult> UpdateFeedItem(UpdateFeedItemViewModel model );
        Task<GrainOperationResult> UpdatePage(UpdatePageViewModel model );
        Task<GrainOperationResult> UpdateTag(string tagName, string entityId);
    }
}