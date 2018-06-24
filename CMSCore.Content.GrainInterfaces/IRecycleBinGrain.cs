namespace CMSCore.Content.GrainInterfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public interface IRecycleBinGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> MoveCommentToRecycleBinByEntityId();
        Task<GrainOperationResult> MoveFeedItemToRecycleBinByEntityId();
        Task<GrainOperationResult> MoveFeedToRecycleBinByEntityId();
        Task<GrainOperationResult> MovePageToRecycleBinByEntityId();
        Task<GrainOperationResult> MoveTagToRecycleBinByEntityId();
    }
}