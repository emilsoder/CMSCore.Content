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