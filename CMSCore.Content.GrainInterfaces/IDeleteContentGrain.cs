namespace CMSCore.Content.GrainInterfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public interface IDeleteContentGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> DeleteCommentByEntityId(string commentId);
        Task<GrainOperationResult> DeleteCommentsByFeedItemId(string feedItemId);
        Task<GrainOperationResult> DeleteFeedByEntityId(string entityId);
        Task<GrainOperationResult> DeleteFeedByPageId(string pageId);
        Task<GrainOperationResult> DeleteFeedItemsByFeedId(string feedId);
        Task<GrainOperationResult> DeleteOneFeedItemByEntityId(string entityId);
        Task<GrainOperationResult> DeletePageAndRelatedEntities(string entityId);
        Task<GrainOperationResult> DeleteTagByEntityId(string tagId);
        Task<GrainOperationResult> DeleteTagsByFeedItemId(string feedItemId);
    }
}