using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSCore.Content.Data;
using CMSCore.Content.Models;
using CMSCore.Content.Models.Extensions;
using CMSCore.Content.Repository.Interfaces;
using CMSCore.Content.ViewModels;

namespace CMSCore.Content.Repository.Implementations
{
    public class UpdateContentRepository : IUpdateContentRepository
    {
        private readonly ContentDbContext _context;

        public UpdateContentRepository(ContentDbContext context)
        {
            _context = context;
        }

        #region Update

        Task IUpdateContentRepository.UpdatePage(UpdatePageViewModel model, string entityId, string userId)
        {
            var foundActivePage =
                _context.Pages.FirstOrDefault(x => x.IsActiveVersion && x.EntityId == entityId);
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

        Task IUpdateContentRepository.UpdateFeed(UpdateFeedViewModel model, string entityId, string userId)
        {
            var foundActiveFeed =
                _context.Feeds.FirstOrDefault(x => x.IsActiveVersion && x.EntityId == entityId);
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

     public   Task  UpdateFeedItem(UpdateFeedItemViewModel model, string entityId, string userId)
        {
            var foundActiveFeed =
                _context.FeedItems.FirstOrDefault(x => x.IsActiveVersion && x.EntityId == entityId);

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

            UpdateTagsIfChanged(newFeed.EntityId, model.Tags);

            _context.Add(newFeed);

            return _context.SaveChangesAsync();
        }

        private void UpdateTagsIfChanged(string feedItemId, IList<string> tags)
        {
            var feedItemTags = _context.Tags.Where(x => x.FeedItemId == feedItemId);
            _context.RemoveRange(feedItemTags);

            var tagsToAdd = tags.AsTagsEnumerable(feedItemId);
            _context.AddRange(tagsToAdd);
        }

        Task IUpdateContentRepository.UpdateTag(string newTagName, string tagId, string userId)
        {
            var activeTag = _context.Tags.FirstOrDefault(x => x.IsActiveVersion && x.EntityId == tagId);
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

        #endregion
    }
}