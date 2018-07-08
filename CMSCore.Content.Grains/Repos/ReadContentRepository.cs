namespace CMSCore.Content.Grains.Repos
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Extensions;
    using GrainInterfaces.Messages;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class ReadContentRepository : IReadContentRepository
    {
        private readonly ContentDbContext _context;

        public ReadContentRepository(ContentDbContext context)
        {
            _context = context;
            _context.Pages
                .Include(x => x.Content)
                .ThenInclude(x => x.ContentVersions)
                .Include(x => x.Feed)
                .ThenInclude(x => x.FeedItems)
                .ThenInclude(x => x.Comments)
                .ThenInclude(x => x.Content)
                .Load();

            _context.Feeds.Include(x => x.FeedItems)
                .ThenInclude(x => x.Content)
                .ThenInclude(x => x.ContentVersions)
                .Load();

            _context.FeedItems.Include(x => x.Tags).Load();
        }

        public async Task<IEnumerable<PageViewModel>> GetAllPages()
        {
            var pages = _context.Set<Page>();

            var viewModels = await pages.Select(page => new PageViewModel
            {
                Content = page.Content.Value,
                Id = page.Id,
                Date = page.Created,
                Modified = page.Modified,
                Name = page.Name,
                NormalizedName = page.NormalizedName,
                Feed = page.Feed.ConvertToViewModel()
            })?.ToListAsync();

            return viewModels;
        }

        public async Task<FeedViewModel> GetFeed(string pageId)
        {
            var feed = await _context.Set<Feed>().SingleOrDefaultAsync(x => x.PageId == pageId);

            if (feed == null) return null;

            var feedItems = (await ((IReadContentRepository) this).GetFeedItems(feed.Id)).ToArray();


            return new FeedViewModel
            {
                Id = feed.Id,
                Date = feed.Created,
                Modified = feed.Modified,
                Name = feed.Name,
                NormalizedName = feed.NormalizedName,
                FeedItems = feedItems
            };
        }

        public async Task<FeedItemViewModel> GetFeedItem(string feedItemId)
        {
            var feedItem = await _context.Set<FeedItem>().FirstOrDefaultAsync(x => x.Id == feedItemId);

            return feedItem?.ConvertToViewModel();
        }

        public async Task<FeedItemViewModel> GetFeedItemByNormalizedName(string normalizedName)
        {
            var feedItem = await _context.Set<FeedItem>().FirstOrDefaultAsync(x => x.NormalizedTitle == normalizedName);

            return feedItem?.ConvertToViewModel();
        }

        public async Task<IEnumerable<FeedItemPreviewViewModel>> GetFeedItems(string feedId)
        {
            var feedItems = await _context.Set<FeedItem>()
                ?.Where(x => x.FeedId == feedId)
                ?.ToListAsync();

            return feedItems?.Select(x => x.ConvertToPreviewViewModel())
                ;
        }

        public async Task<PageViewModel> GetPage(string pageId)
        {
            var page = await _context.Set<Page>().FirstOrDefaultAsync(x => x.Id == pageId);
            if (page == null) return null;

            return new PageViewModel
            {
                Content = page.Content?.Value,
                Id = page.Id,
                Date = page.Created,
                Modified = page.Modified,
                Name = page.Name,
                NormalizedName = page.NormalizedName,
                Feed = page.Feed?.ConvertToViewModel()
            };
        }


        public async Task<PageViewModel> GetPageByNormalizedName(string normalizedName)
        {
            var page = await _context.Set<Page>().FirstOrDefaultAsync(x => x.NormalizedName == normalizedName);
            if (page == null) return null;

            return new PageViewModel
            {
                Content = page.Content?.Value,
                Id = page.Id,
                Date = page.Created,
                Modified = page.Modified,
                Name = page.Name,
                NormalizedName = page.NormalizedName,
                Feed = page.Feed?.ConvertToViewModel()
            };
        }

        public async Task<IEnumerable<PageTreeViewModel>> GetPageTree()
        {
            var pages = await _context.Set<Page>().ToListAsync();

            return pages.Select(x => new PageTreeViewModel
                {
                    Id = x.Id,
                    Date = x.Created,
                    Name = x.Name,
                    NormalizedName = x.NormalizedName
                })
                ;
        }

        public async Task<IEnumerable<TagViewModel>> GetTags(string feedItemId)
        {
            var tags = await _context.Set<Tag>().Where(x => x.FeedItemId == feedItemId).ToListAsync();

            var vm = tags?.Select(x => x.ConvertToViewModel());
            return vm;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var vms = _context.Set<User>().Select(x => new UserViewModel
            {
                Id = x.Id,
                Created = x.Created,
                Modified = x.Modified,
                Email = x.Email,
                FirstName = x.FirstName,
                IdentityUserId = x.IdentityUserId,
                LastName = x.LastName
            });

            return await vms.ToListAsync();
        }

        public async Task<IEnumerable<TagViewModel>> GetTags()
        {
            var eq = new TagComparer();
            var tagsDistinct = await _context.Tags.Distinct(eq).ToListAsync();
            return tagsDistinct?.Select(x => x.ConvertToViewModel());
        }
    }

    public class TagComparer : IEqualityComparer<Tag>
    {
        public bool Equals(Tag x, Tag y)
        {
            if (x.NormalizedName.Equals(y.NormalizedName))
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(Tag obj)
        {
            return obj.GetHashCode();
        }
    }
}