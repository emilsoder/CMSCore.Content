using System.Threading.Tasks;

namespace CMSCore.Content.Repository.Interfaces
{
    public interface IDeleteContentRepository
    {
        Task DeleteCommentByEntityId(string commentId);
        Task DeleteTagByEntityId(string tagId);
        Task DeletePageAndRelatedEntities(string entityId, bool saveChanges = true);
        Task DeleteFeedByPageId(string pageId, bool saveChanges = true);
        Task DeleteFeedByEntityId(string entityId, bool saveChanges = true);
        Task DeleteFeedItemsByFeedId(string feedId, bool saveChanges = true);
        Task DeleteOneFeedItemByEntityId(string entityId, bool saveChanges = true);
        Task DeleteTagsByFeedItemId(string feedItemId, bool saveChanges = true);
        Task DeleteCommentsByFeedItemId(string feedItemId, bool saveChanges = true);
    }
}