namespace CMSCore.Content.Grains.Repos.Interfaces
{
    using System.Threading.Tasks;

    public interface IDeleteContentRepository
    {
        Task DeleteCommentByEntityId(string commentId);
        Task DeleteCommentsByFeedItemId(string feedItemId, bool saveChanges = true);
        Task DeleteFeedByEntityId(string entityId, bool saveChanges = true);
        Task DeleteFeedByPageId(string pageId, bool saveChanges = true);
        Task DeleteFeedItemsByFeedId(string feedId, bool saveChanges = true);
        Task DeleteOneFeedItemByEntityId(string entityId, bool saveChanges = true);
        Task DeletePageAndRelatedEntities(string entityId, bool saveChanges = true);
        Task DeleteTagByEntityId(string tagId);
        Task DeleteTagsByFeedItemId(string feedItemId, bool saveChanges = true);
    }
}