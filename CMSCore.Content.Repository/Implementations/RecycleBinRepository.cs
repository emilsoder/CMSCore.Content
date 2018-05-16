using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSCore.Content.Data;
using CMSCore.Content.Models;
using CMSCore.Content.Repository.Interfaces;

namespace CMSCore.Content.Repository.Implementations
{
    public class RecycleBinRepository : IRecycleBinRepository
    {
        private readonly ContentDbContext _context;

        public RecycleBinRepository(ContentDbContext context)
        {
            _context = context;
        }

        #region RecycleBinRepository

        Task IRecycleBinRepository.MovePageToRecycleBinByEntityId(string pageId)
        {
            MarkPageAsDeletedByEntityId(pageId);

            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveFeedToRecycleBinByEntityId(string feedId)
        {
            MarkFeedAsDeletedByEntityId(feedId);

            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveFeedItemToRecycleBinByEntityId(string feedItemId)
        {
            var feedItems = _context.FeedItems.Where(x => x.EntityId == feedItemId);

            if (!feedItems.Any()) return Task.FromException(new Exception("FeedItem to recycle not found"));
            MarkCommentsAsDeletedByFeedItemId(feedItemId);
            MarkTagsAsDeletedByFeedItemId(feedItemId);

            MarkAsDeletedAndUpdate(feedItems);
            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveCommentToRecycleBinByEntityId(string commentId)
        {
            var comments = _context.Comments?.Where(x => x.EntityId == commentId);

            if (comments == null || !comments.Any())
                return Task.FromException(new Exception("Comment to recycle not found"));

            MarkAsDeletedAndUpdate(comments);
            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveTagToRecycleBinByEntityId(string tagId)
        {
            var tags = _context.Tags?.Where(x => x.EntityId == tagId);

            if (tags == null || !tags.Any()) return Task.FromException(new Exception("Tag to recycle not found"));

            MarkAsDeletedAndUpdate(tags);
            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.RestoreFromRecycleBin<TEntityType>(string entityId)
        {
            var entitiesToRestore = _context.Set<TEntityType>()?.Where(x => x.EntityId == entityId);
            if (entitiesToRestore == null || !entitiesToRestore.Any()) return _context.SaveChangesAsync();
            foreach (var entity in entitiesToRestore)
            {
                entity.MarkedToDelete = false;
                _context.Update(entity);
            }

            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.RestoreOnePageFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var page = _context.Pages?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (page == null || !page.Any()) return Task.CompletedTask;
            foreach (var p in page)
            {
                p.MarkedToDelete = false;
                p.Modified = DateTime.Now;
                _context.Update(p);
            }

            ((IRecycleBinRepository) this).RestoreFeedsFromRecycleBinByPageId(entityId, false);


            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreOneFeedFromRecycleBinByEntityId(string entityId, bool saveChanges = true)
        {
            var feeds = _context.Feeds?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feeds == null || !feeds.Any()) return Task.CompletedTask;
            foreach (var feed in feeds)
            {
                feed.MarkedToDelete = false;
                feed.Modified = DateTime.Now;
                ((IRecycleBinRepository) this).RestoreFeedItemsFromRecycleBinByFeedId(entityId, false);
                _context.Update(feed);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreOneFeedItemFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var feedItems = _context.FeedItems?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feedItems == null || !feedItems.Any()) return Task.CompletedTask;
            foreach (var feedItem in feedItems)
            {
                feedItem.MarkedToDelete = false;
                feedItem.Modified = DateTime.Now;
                _context.Update(feedItem);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreFeedsFromRecycleBinByPageId(string pageId, bool saveChanges)
        {
            var feeds = _context.Feeds?.Where(x => x.PageId == pageId && x.MarkedToDelete);
            if (feeds == null || !feeds.Any()) return Task.CompletedTask;
            foreach (var feed in feeds)
            {
                feed.MarkedToDelete = false;
                feed.Modified = DateTime.Now;
                ((IRecycleBinRepository) this).RestoreFeedItemsFromRecycleBinByFeedId(feed.EntityId, false);
                _context.Update(feed);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreFeedItemsFromRecycleBinByFeedId(string feedId, bool saveChanges)
        {
            var feedItems = _context.FeedItems?.Where(x => x.FeedId == feedId && x.MarkedToDelete);
            if (feedItems == null || !feedItems.Any()) return Task.CompletedTask;
            foreach (var feedItem in feedItems)
            {
                feedItem.MarkedToDelete = false;
                feedItem.Modified = DateTime.Now;
                _context.Update(feedItem);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges)
        {
            var comments = _context.Comments?.Where(x => x.FeedItemId == feedItemId && x.MarkedToDelete);
            if (comments == null || !comments.Any()) return Task.CompletedTask;
            foreach (var comment in comments)
            {
                comment.MarkedToDelete = false;
                comment.Modified = DateTime.Now;
                _context.Update(comment);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreTagsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges)
        {
            var tags = _context.Tags?.Where(x => x.FeedItemId == feedItemId && x.MarkedToDelete);
            if (tags == null || !tags.Any()) return Task.CompletedTask;
            foreach (var tag in tags)
            {
                tag.MarkedToDelete = false;
                tag.Modified = DateTime.Now;
                _context.Update(tag);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreCommentsFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var comments = _context.Comments?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (comments == null || !comments.Any()) return Task.CompletedTask;
            foreach (var comment in comments)
            {
                comment.MarkedToDelete = false;
                comment.Modified = DateTime.Now;
                _context.Update(comment);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.RestoreTagsFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var tags = _context.Tags?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (tags == null || !tags.Any()) return Task.CompletedTask;
            foreach (var tag in tags)
            {
                tag.MarkedToDelete = false;
                tag.Modified = DateTime.Now;
                _context.Update(tag);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task IRecycleBinRepository.EmptyRecycleBin<TEntityType>()
        {
            var set = _context.Set<TEntityType>()?.Where(x => x.MarkedToDelete);

            if (set == null || !set.Any())
                return Task.CompletedTask;

            _context.RemoveRange(set);

            return _context.SaveChangesAsync();
        }

        #region Private helpers

        private void MarkPageAsDeletedByEntityId(string entityId)
        {
            var pages = _context.Pages?.Where(x => x.EntityId == entityId);
            if (pages == null || !pages.Any()) return;
            MarkFeedAsDeletedByPageId(pages.First().EntityId);
            MarkAsDeletedAndUpdate(pages);
        }

        private void MarkFeedAsDeletedByPageId(string pageId)
        {
            var feed = _context.Feeds?.Where(x => x.PageId == pageId);
            if (feed == null || !feed.Any()) return;
            MarkFeedItemsAsDeletedByFeedId(feed.First().EntityId);
            MarkAsDeletedAndUpdate(feed);
        }

        private void MarkFeedAsDeletedByEntityId(string entityId)
        {
            var feed = _context.Feeds?.Where(x => x.EntityId == entityId);
            if (feed == null || !feed.Any()) return;
            MarkFeedItemsAsDeletedByFeedId(feed.First().EntityId);
            MarkAsDeletedAndUpdate(feed);
        }

        private void MarkFeedItemsAsDeletedByFeedId(string feedId)
        {
            var feedItems = _context.FeedItems?.Where(x => x.FeedId == feedId);

            if (feedItems == null || !feedItems.Any()) return;

            var ids = feedItems.Select(x => x.EntityId);
            if (ids.Any())
                foreach (var entityId in ids)
                {
                    MarkCommentsAsDeletedByFeedItemId(entityId);
                    MarkTagsAsDeletedByFeedItemId(entityId);
                }

            MarkAsDeletedAndUpdate(feedItems);
        }

        private void MarkCommentsAsDeletedByFeedItemId(string feedItemId)
        {
            var comments = _context.Comments?.Where(x => x.FeedItemId == feedItemId);
            if (comments != null && comments.Any()) MarkAsDeletedAndUpdate(comments);
        }

        private void MarkTagsAsDeletedByFeedItemId(string feedItemId)
        {
            var tags = _context.Tags?.Where(x => x.FeedItemId == feedItemId);
            if (tags != null && tags.Any()) MarkAsDeletedAndUpdate(tags);
        }

        private void MarkAsDeletedAndUpdate<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase
        {
            foreach (var entity in entities)
            {
                entity.MarkedToDelete = true;
                entity.Modified = DateTime.Now;
                _context.Update(entity);
            }
        }

        #endregion

        #endregion
    }
}