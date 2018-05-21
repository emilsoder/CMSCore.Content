namespace CMSCore.Content.Repository.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using CMSCore.Content.Data;
    using CMSCore.Content.Models;
    using CMSCore.Content.Repository.Interfaces;

    public class RestoreContentRepository : IRestoreContentRepository
    {
        private readonly ContentDbContext _context;

        public RestoreContentRepository(ContentDbContext context)
        {
            _context = context;
        }

        public Task RestoreCommentsFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var comments = _context.Set<Comment>()?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (comments == null || !comments.Any()) return Task.CompletedTask;
            foreach (var comment in comments)
            {
                comment.MarkedToDelete = false;
                comment.Modified = DateTime.Now;
                _context.Update(comment);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges)
        {
            var comments = _context.Set<Comment>()?.Where(x => x.FeedItemId == feedItemId && x.MarkedToDelete);
            if (comments == null || !comments.Any()) return Task.CompletedTask;
            foreach (var comment in comments)
            {
                comment.MarkedToDelete = false;
                comment.Modified = DateTime.Now;
                _context.Update(comment);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreFeedItemsFromRecycleBinByFeedId(string feedId, bool saveChanges)
        {
            var feedItems = _context.Set<FeedItem>()?.Where(x => x.FeedId == feedId && x.MarkedToDelete);
            if (feedItems == null || !feedItems.Any()) return Task.CompletedTask;
            foreach (var feedItem in feedItems)
            {
                feedItem.MarkedToDelete = false;
                feedItem.Modified = DateTime.Now;
                _context.Update(feedItem);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreFeedsFromRecycleBinByPageId(string pageId, bool saveChanges)
        {
            var feeds = _context.Set<Feed>()?.Where(x => x.PageId == pageId && x.MarkedToDelete);
            if (feeds == null || !feeds.Any()) return Task.CompletedTask;
            foreach (var feed in feeds)
            {
                feed.MarkedToDelete = false;
                feed.Modified = DateTime.Now;
                RestoreFeedItemsFromRecycleBinByFeedId(feed.EntityId, false);
                _context.Update(feed);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreFromRecycleBin<TEntityType>(string entityId) where TEntityType : EntityBase
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

        public Task RestoreOneFeedFromRecycleBinByEntityId(string entityId, bool saveChanges = true)
        {
            var feeds = _context.Set<Feed>()?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feeds == null || !feeds.Any()) return Task.CompletedTask;
            foreach (var feed in feeds)
            {
                feed.MarkedToDelete = false;
                feed.Modified = DateTime.Now;
                RestoreFeedItemsFromRecycleBinByFeedId(entityId, false);
                _context.Update(feed);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreOneFeedItemFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var feedItems = _context.Set<FeedItem>()?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (feedItems == null || !feedItems.Any()) return Task.CompletedTask;
            foreach (var feedItem in feedItems)
            {
                feedItem.MarkedToDelete = false;
                feedItem.Modified = DateTime.Now;
                _context.Update(feedItem);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreOnePageFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var page = _context.Set<Page>()?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (page == null || !page.Any()) return Task.CompletedTask;
            foreach (var p in page)
            {
                p.MarkedToDelete = false;
                p.Modified = DateTime.Now;
                _context.Update(p);
            }

            RestoreFeedsFromRecycleBinByPageId(entityId, false);


            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreTagsFromRecycleBinByEntityId(string entityId, bool saveChanges)
        {
            var tags = _context.Set<Tag>()?.Where(x => x.EntityId == entityId && x.MarkedToDelete);
            if (tags == null || !tags.Any()) return Task.CompletedTask;
            foreach (var tag in tags)
            {
                tag.MarkedToDelete = false;
                tag.Modified = DateTime.Now;
                _context.Update(tag);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        public Task RestoreTagsFromRecycleBinByFeedItemId(string feedItemId, bool saveChanges)
        {
            var tags = _context.Set<Tag>()?.Where(x => x.FeedItemId == feedItemId && x.MarkedToDelete);
            if (tags == null || !tags.Any()) return Task.CompletedTask;
            foreach (var tag in tags)
            {
                tag.MarkedToDelete = false;
                tag.Modified = DateTime.Now;
                _context.Update(tag);
            }

            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }
    }
}