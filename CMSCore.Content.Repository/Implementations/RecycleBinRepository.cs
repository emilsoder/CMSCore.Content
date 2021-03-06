﻿namespace CMSCore.Content.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CMSCore.Content.Data;
    using CMSCore.Content.Models;
    using CMSCore.Content.Repository.Interfaces;

    public class RecycleBinRepository : IRecycleBinRepository
    {
        private readonly ContentDbContext _context;

        public RecycleBinRepository(ContentDbContext context)
        {
            _context = context;
        }

        Task IRecycleBinRepository.EmptyRecycleBin<TEntityType>()
        {
            var set = _context.Set<TEntityType>()?.Where(x => x.MarkedToDelete);

            if (set == null || !set.Any())
                return Task.CompletedTask;

            _context.RemoveRange(set);

            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveCommentToRecycleBinByEntityId(string commentId)
        {
            var comments = _context.Set<Comment>()?.Where(x => x.EntityId == commentId);

            if (comments == null || !comments.Any())
                return Task.FromException(new Exception("Comment to recycle not found"));

            MarkAsDeletedAndUpdate(comments);
            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveFeedItemToRecycleBinByEntityId(string feedItemId)
        {
            var feedItems = _context.Set<FeedItem>().Where(x => x.EntityId == feedItemId);

            if (!feedItems.Any()) return Task.FromException(new Exception("FeedItem to recycle not found"));
            MarkCommentsAsDeletedByFeedItemId(feedItemId);
            MarkTagsAsDeletedByFeedItemId(feedItemId);

            MarkAsDeletedAndUpdate(feedItems);
            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveFeedToRecycleBinByEntityId(string feedId)
        {
            MarkFeedAsDeletedByEntityId(feedId);

            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MovePageToRecycleBinByEntityId(string pageId)
        {
            MarkPageAsDeletedByEntityId(pageId);

            return _context.SaveChangesAsync();
        }

        Task IRecycleBinRepository.MoveTagToRecycleBinByEntityId(string tagId)
        {
            var tags = _context.Set<Tag>()?.Where(x => x.EntityId == tagId);

            if (tags == null || !tags.Any()) return Task.FromException(new Exception("Tag to recycle not found"));

            MarkAsDeletedAndUpdate(tags);
            return _context.SaveChangesAsync();
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

        private void MarkCommentsAsDeletedByFeedItemId(string feedItemId)
        {
            var comments = _context.Set<Comment>()?.Where(x => x.FeedItemId == feedItemId);
            if (comments != null && comments.Any()) MarkAsDeletedAndUpdate(comments);
        }

        private void MarkFeedAsDeletedByEntityId(string entityId)
        {
            var feed = _context.Set<Feed>()?.Where(x => x.EntityId == entityId);
            if (feed == null || !feed.Any()) return;
            MarkFeedItemsAsDeletedByFeedId(feed.First().EntityId);
            MarkAsDeletedAndUpdate(feed);
        }

        private void MarkFeedAsDeletedByPageId(string pageId)
        {
            var feed = _context.Set<Feed>()?.Where(x => x.PageId == pageId);
            if (feed == null || !feed.Any()) return;
            MarkFeedItemsAsDeletedByFeedId(feed.First().EntityId);
            MarkAsDeletedAndUpdate(feed);
        }

        private void MarkFeedItemsAsDeletedByFeedId(string feedId)
        {
            var feedItems = _context.Set<FeedItem>()?.Where(x => x.FeedId == feedId);

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

        private void MarkPageAsDeletedByEntityId(string entityId)
        {
            var pages = _context.Set<Page>()?.Where(x => x.EntityId == entityId);
            if (pages == null || !pages.Any()) return;
            MarkFeedAsDeletedByPageId(pages.First().EntityId);
            MarkAsDeletedAndUpdate(pages);
        }

        private void MarkTagsAsDeletedByFeedItemId(string feedItemId)
        {
            var tags = _context.Set<Tag>()?.Where(x => x.FeedItemId == feedItemId);
            if (tags != null && tags.Any()) MarkAsDeletedAndUpdate(tags);
        }
    }
}