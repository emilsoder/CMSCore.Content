namespace CMSCore.Content.GrainInterfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public interface IRecycleBinGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> MoveCommentToRecycleBinByEntityId(string commentId);
        Task<GrainOperationResult> MoveFeedItemToRecycleBinByEntityId(string feedItemId);
        Task<GrainOperationResult> MoveFeedToRecycleBinByEntityId(string feedId);
        Task<GrainOperationResult> MovePageToRecycleBinByEntityId(string pageId);
        Task<GrainOperationResult> MoveTagToRecycleBinByEntityId(string tagId);
    }
}