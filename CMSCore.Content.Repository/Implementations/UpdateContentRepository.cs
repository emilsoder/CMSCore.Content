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
            var foundActiveFeed = _context.FeedItems.FirstOrDefault(x =>  x.Id == model.EntityId);

            if (foundActiveFeed == null) return Task.FromException(new Exception("FeedItem to update not found."));

   

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateFeed(UpdateFeedViewModel model,  string userId)
        {
            var foundActiveFeed =
                _context.Set<Feed>().FirstOrDefault(x => x.Id == model.EntityId);
            if (foundActiveFeed == null) return Task.FromException(new Exception("Feed to update not found."));

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdatePage(UpdatePageViewModel model, string userId)
        {
            var foundActivePage =
                _context.Set<Page>().FirstOrDefault(x => x.Id == model.EntityId);

            if (foundActivePage == null) return Task.FromException(new Exception("Page to update not found."));

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateTag(string newTagName, string tagId, string userId)
        {
            var activeTag = _context.Set<Tag>().FirstOrDefault(x => x.Id == tagId);
            if (activeTag == null) return Task.FromException(new Exception("Tag to update not found."));

            activeTag.Name = newTagName;
            activeTag.Modified = DateTime.Now;
            _context.Update(activeTag);


            return _context.SaveChangesAsync();
        }

        //private int GetNextVersion<T>(string entityId) where T : EntityBase
        //{
        //    var set = _context.Set<T>().Where(x => x.Id == entityId).Select(x => x.Version);
        //    var orderedVersions = set.OrderByDescending(x => x);
        //    var v = orderedVersions.FirstOrDefault();
        //    return v + 1;
        //}

        private void UpdateTagsIfChanged(string feedItemId, IList<string> tags, string userId)
        {
            var feedItemTags = _context.Set<Tag>().Where(x => x.FeedItemId == feedItemId);
            _context.RemoveRange(feedItemTags);

            var tagsToAdd = tags.AsTagsEnumerable(feedItemId, userId);
            _context.AddRange(tagsToAdd);
        }
    }
}