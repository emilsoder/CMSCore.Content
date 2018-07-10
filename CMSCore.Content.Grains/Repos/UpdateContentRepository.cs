namespace CMSCore.Content.Grains.Repos
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using GrainInterfaces.Messages;
    using Interfaces;

    public class UpdateContentRepository : IUpdateContentRepository
    {
        private readonly ContentDbContext _context;

        public UpdateContentRepository(ContentDbContext context)
        {
            _context = context;
        }

        public Task UpdateFeedItem(UpdateFeedItemViewModel model)
        {
            var foundActiveFeed = _context.FeedItems.FirstOrDefault(x =>  x.Id == model.Id);

            if (foundActiveFeed == null) return Task.FromException(new Exception("FeedItem to update not found."));
             
            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateFeed(UpdateFeedViewModel model)
        {
            var foundActiveFeed =
                _context.Set<Feed>().FirstOrDefault(x => x.Id == model.Id);
            if (foundActiveFeed == null) return Task.FromException(new Exception("Feed to update not found."));

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdatePage(UpdatePageViewModel model)
        {
            var foundActivePage =
                _context.Set<Page>().FirstOrDefault(x => x.Id == model.Id);

            if (foundActivePage == null) return Task.FromException(new Exception("Page to update not found."));

            return _context.SaveChangesAsync();
        }

        Task IUpdateContentRepository.UpdateTag(string newTagName, string tagId)
        {
            var activeTag = _context.Set<Tag>().FirstOrDefault(x => x.Id == tagId);
            if (activeTag == null) return Task.FromException(new Exception("Tag to update not found."));

            activeTag.Name = newTagName;
            activeTag.Modified = DateTime.Now;
            _context.Update(activeTag);


            return _context.SaveChangesAsync();
        }
 
    }
}