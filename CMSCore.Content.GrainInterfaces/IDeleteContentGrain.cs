namespace CMSCore.Content.GrainInterfaces
{
    using System.Threading.Tasks;
    using Messages;
    using Orleans;
 
    public interface IDeleteContentGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> DeleteCommentByEntityId();
        Task<GrainOperationResult> _DeleteCommentsByFeedItemId();
        Task<GrainOperationResult> DeleteFeedByEntityId();
        Task<GrainOperationResult> DeleteFeedByPageId();
        Task<GrainOperationResult> DeleteFeedItemsByFeedId();
        Task<GrainOperationResult> DeleteOneFeedItemByEntityId();
        Task<GrainOperationResult> DeletePageAndRelatedEntities();
        Task<GrainOperationResult> DeleteTagByEntityId();
        Task<GrainOperationResult> DeleteTagsByFeedItemId();
    }
}