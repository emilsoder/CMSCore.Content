using System.Collections.Generic;
using System.Threading.Tasks;
using CMSCore.Content.GrainInterfaces;
using Orleans;

namespace CMSCore.Content.Grains
{
    using System.Linq;
    using Data;
    using Data.Models;
    using Extensions;
    using GrainInterfaces.Messages;
    using Microsoft.EntityFrameworkCore;

    public class ReadContentGrain : Grain, IReadContentGrain
    {
        private readonly ContentDbContext _context;

        public ReadContentGrain(ContentDbContext context)
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

        public async Task<FeedViewModel> GetFeedByPageId(string pageId)
        {
            var id = this.GetPrimaryKeyString();

            return await this.GetFeed(id);
        }

        public async Task<FeedItemViewModel> GetFeedItemById(string feedItemId)
        {
            var id = this.GetPrimaryKeyString();

            return await this.GetFeedItem(id);
        }

        public async Task<IEnumerable<FeedItemPreviewViewModel>> FeedItemsByFeedId(string feedId)
        {
            var id = this.GetPrimaryKeyString();

            return await this.GetFeedItems(id);
        }

        public async Task<PageViewModel> FindPageById(string pageId)
        {
            var id = this.GetPrimaryKeyString();

            return await this.GetPage(id);
        }

        public async Task<PageViewModel> FindPageByNormalizedName()
        {
            var normalizedName = this.GetPrimaryKeyString();

            return await this.GetPageByNormalizedName(normalizedName);
        }

        public async Task<FeedItemViewModel> FindFeedItemByNormalizedName()
        {
            var normalizedName = this.GetPrimaryKeyString();

            return await this.GetFeedItemByNormalizedName(normalizedName);
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
            });
        }

        public async Task<IEnumerable<TagViewModel>> GetTagsByFeedItemId(string feedItemId)
        {
            var id = this.GetPrimaryKeyString();

            return await this.GetTags(id);
        }

        public async Task<IEnumerable<TagViewModel>> GetTags()
        {
            var eq = new TagComparer();
            var tagsDistinct = await _context.Tags.Distinct(eq).ToListAsync();
            return tagsDistinct?.Select(x => x.ConvertToViewModel());
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

        public async Task<IEnumerable<PageViewModel>> GetAllPages()
        {
            var pages = _context.Set<Page>().Include(x => x.Feed).ThenInclude(x => x.FeedItems).Include(x => x.Content).ThenInclude(x => x.ContentVersions);

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

            var feedItems = await GetFeedItems(feed.Id);


            return new FeedViewModel
            {
                Id = feed.Id,
                Date = feed.Created,
                Modified = feed.Modified,
                Name = feed.Name,
                NormalizedName = feed.NormalizedName,
                FeedItems = feedItems.ToArray()
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
                .Where(x => x.FeedId == feedId)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .Include(x => x.Content)
                .ThenInclude(x => x.ContentVersions)
                .ToListAsync();

            return feedItems?.Select(x => x.ConvertToPreviewViewModel());
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


        public async Task<IEnumerable<TagViewModel>> GetTags(string feedItemId)
        {
            var tags = await _context.Set<Tag>().Where(x => x.FeedItemId == feedItemId).ToListAsync();

            var vm = tags?.Select(x => x.ConvertToViewModel());
            return vm;
        }


        internal class TagComparer : IEqualityComparer<Tag>
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
}