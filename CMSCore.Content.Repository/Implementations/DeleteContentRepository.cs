using System.Linq;
using System.Threading.Tasks;
using CMSCore.Content.Data;
using CMSCore.Content.Repository.Interfaces;

namespace CMSCore.Content.Repository.Implementations
{
    using CMSCore.Content.Models;
    using Microsoft.EntityFrameworkCore;

    public class DeleteContentRepository : IDeleteContentRepository
    {
        private readonly DbContext _context;

        public DeleteContentRepository(ContentDbContext context)
        {
            _context = context;
        }

        #region Delete

        // -------------

        Task IDeleteContentRepository.DeletePageAndRelatedEntities(string entityId, bool saveChanges)
        {
            if (!DeletePageAndRelatedEntities(entityId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeletePageAndRelatedEntities(string entityId)
        {
            var page = _context.Set<Page>()?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (page == null || !page.Any()) return false;

            DeleteFeedByPageId(entityId);
            _context.RemoveRange(page);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteFeedByPageId(string pageId, bool saveChanges)
        {
            if (!DeleteFeedByPageId(pageId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteFeedByPageId(string pageId)
        {
            var feedToDelete = _context.Set<Feed>()?.Where(x => x.PageId == pageId && x.MarkedToDelete);
            if (feedToDelete == null || !feedToDelete.Any()) return false;
            DeleteFeedItemsByFeedId(feedToDelete.First().EntityId);
            _context.RemoveRange(feedToDelete);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteFeedByEntityId(string entityId, bool saveChanges)
        {
            if (!DeleteFeedByEntityId(entityId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteFeedByEntityId(string entityId)
        {
            var feedToDelete = _context.Set<Feed>()?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feedToDelete == null || !feedToDelete.Any()) return false;
            DeleteFeedItemsByFeedId(entityId);
            _context.RemoveRange(feedToDelete);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteFeedItemsByFeedId(string feedId, bool saveChanges)
        {
            if (!DeleteFeedItemsByFeedId(feedId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteFeedItemsByFeedId(string feedId)
        {
            var feedItem = _context.Set<FeedItem>()?.Where(x => x.FeedId == feedId && x.MarkedToDelete);
            if (feedItem == null || !feedItem.Any()) return false;

            var feedItemId = feedItem.First().EntityId;

            DeleteTagsByFeedItemId(feedItemId);
            DeleteCommentsByFeedItemId(feedItemId);
            _context.RemoveRange(feedItem);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteOneFeedItemByEntityId(string entityId, bool saveChanges)
        {
            if (!DeleteOneFeedItemByEntityId(entityId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteOneFeedItemByEntityId(string entityId)
        {
            var feedItem = _context.Set<FeedItem>()?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feedItem == null || !feedItem.Any()) return false;

            DeleteTagsByFeedItemId(entityId);
            DeleteCommentsByFeedItemId(entityId);
            _context.RemoveRange(feedItem);
            return true;
        }

        // -------------

        Task IDeleteContentRepository.DeleteTagsByFeedItemId(string feedItemId, bool saveChanges)
        {
            if (!DeleteTagsByFeedItemId(feedItemId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteTagsByFeedItemId(string feedItemId)
        {
            var tags = _context.Set<Tag>()?.Where(x => x.FeedItemId == feedItemId);
            if (tags == null || !tags.Any()) return false;
            _context.RemoveRange(tags);
            return true;
        }

        // -------------
        Task IDeleteContentRepository.DeleteCommentsByFeedItemId(string feedItemId, bool saveChanges)
        {
            if (!DeleteCommentsByFeedItemId(feedItemId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool DeleteCommentsByFeedItemId(string feedItemId)
        {
            var comments = _context.Set<Comment>()?.Where(x => x.FeedItemId == feedItemId);
            if (comments == null || !comments.Any()) return false;
            _context.RemoveRange(comments);
            return true;
        }

        // -------------
        Task  IDeleteContentRepository.DeleteCommentByEntityId(string commentId)
        {
            if (!DeleteCommentByEntityId(commentId)) return Task.CompletedTask;

            return _context.SaveChangesAsync();
        }

        private bool DeleteCommentByEntityId(string commentId)
        {
            var comment = _context.Set<Comment>()?.FirstOrDefault(x => x.EntityId == commentId);
            if (comment == null) return false;
            _context.Remove(comment);
            return true;
        }

        // -------------
        Task IDeleteContentRepository.DeleteTagByEntityId(string tagId)
        {
            if (!DeleteTagByEntityId(tagId)) return Task.CompletedTask;
            return _context.SaveChangesAsync();
        }

        private bool DeleteTagByEntityId(string tagId)
        {
            var tag = _context.Set<Tag>()?.FirstOrDefault(x => x.EntityId == tagId);
            if (tag == null) return false;
            _context.Remove(tag);
            return true;
        }

        // -------------

        #endregion
    }
}