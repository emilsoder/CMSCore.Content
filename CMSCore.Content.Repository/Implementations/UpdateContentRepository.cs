namespace CMSCore.Content.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CMSCore.Content.Data;
    using CMSCore.Content.Models;
    using CMSCore.Content.Models.Extensions;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;

    public class UpdateContentRepository : IUpdateContentRepository
    {
        private readonly ContentDbContext _context;

        public UpdateContentRepository(ContentDbContext context)
        {
            _context = context;
        }

        public Task UpdateFeedItem(UpdateFeedItemViewModel model, string userId)
        {
            var foundActiveFeed = _context.FeedItems.FirstOrDefault(x => x.IsActiveVersion && x.EntityId == model.EntityId);

            if (foundActiveFeed == null) return Task.FromException(new Exception("FeedItem to update not found."));

            foundActiveFeed.IsActiveVersion = false;
            foundActiveFeed.Modified = DateTime.Now;
            _context.Update(foundActiveFeed);
            _context.SaveChanges();

            var newFeed = foundActiveFeed;
            newFeed.Id = Guid.NewGuid().ToString();
            newFeed.IsActiveVersion = true;
            newFeed.Version = GetNextVersion<FeedItem>(foundActiveFeed.EntityId);

            newFeed.CommentsEnabled = model.CommentsEnabled;
            newFeed.Content = model.Content;
            newFeed.Title = model.Title;
            newFeed.CommentsEnabled = model.CommentsEnabled;

            UpdateTagsIfChanged(newFeed.EntityId, model.Tags, userId);

            _context.Add(newFeed);

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateFeed(UpdateFeedViewModel model,  string userId)
        {
            var foundActiveFeed =
                _context.Set<Feed>().FirstOrDefault(x => x.IsActiveVersion && x.EntityId == model.EntityId);
            if (foundActiveFeed == null) return Task.FromException(new Exception("Feed to update not found."));

            foundActiveFeed.IsActiveVersion = false;
            foundActiveFeed.Modified = DateTime.Now;
            _context.Update(foundActiveFeed);
            _context.SaveChanges();

            var newFeed = foundActiveFeed;
            newFeed.Id = Guid.NewGuid().ToString();
            newFeed.IsActiveVersion = true;
            newFeed.Version = GetNextVersion<Feed>(foundActiveFeed.EntityId);
            newFeed.Name = model.Name;
            _context.Add(newFeed);

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdatePage(UpdatePageViewModel model, string userId)
        {
            var foundActivePage =
                _context.Set<Page>().FirstOrDefault(x => x.IsActiveVersion && x.EntityId == model.EntityId);
            if (foundActivePage == null) return Task.FromException(new Exception("Page to update not found."));

            foundActivePage.IsActiveVersion = false;
            foundActivePage.Modified = DateTime.Now;
            _context.Update(foundActivePage);
            _context.SaveChanges();

            var newPage = foundActivePage;
            newPage.Id = Guid.NewGuid().ToString();
            newPage.IsActiveVersion = true;
            newPage.Name = model.Name;
            newPage.Version = GetNextVersion<Page>(foundActivePage.EntityId);
            newPage.Content = model.Content;
            newPage.FeedEnabled = model.FeedEnabled;
            _context.Add(newPage);

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateTag(string newTagName, string tagId, string userId)
        {
            var activeTag = _context.Set<Tag>().FirstOrDefault(x => x.IsActiveVersion && x.EntityId == tagId);
            if (activeTag == null) return Task.FromException(new Exception("Tag to update not found."));

            activeTag.Name = newTagName;
            activeTag.Modified = DateTime.Now;
            _context.Update(activeTag);


            return _context.SaveChangesAsync();
        }

        private int GetNextVersion<T>(string entityId) where T : EntityBase
        {
            var set = _context.Set<T>().Where(x => x.EntityId == entityId).Select(x => x.Version);
            var orderedVersions = set.OrderByDescending(x => x);
            var v = orderedVersions.FirstOrDefault();
            return v + 1;
        }

        private void UpdateTagsIfChanged(string feedItemId, IList<string> tags, string userId)
        {
            var feedItemTags = _context.Set<Tag>().Where(x => x.FeedItemId == feedItemId);
            _context.RemoveRange(feedItemTags);

            var tagsToAdd = tags.AsTagsEnumerable(feedItemId, userId);
            _context.AddRange(tagsToAdd);
        }
    }
}