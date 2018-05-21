namespace CMSCore.Content.Repository.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CMSCore.Content.Data;
    using CMSCore.Content.Models;
    using CMSCore.Content.Models.Extensions;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;

    public class CreateContentRepository : ICreateContentRepository
    {
        private readonly ContentDbContext _context;

        public CreateContentRepository(ContentDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateComment(CreateCommentViewModel model, string feedItemId, string userId)
        {
            var comment = new Comment(feedItemId, model.Text, model.FullName);

            _context.Add(comment);

            await _context.SaveChangesAsync();
            return comment.EntityId;
        }

        public async Task<string> CreateFeedItem(CreateFeedItemViewModel model, string feedId, string userId)
        {
            var feedItem = new FeedItem(feedId, model.Title, model.Description, model.Content, model.CommentsEnabled);

            if (model.Tags != null && model.Tags.Any())
            {
                var tags = model.Tags.AsTagsEnumerable(feedItem.EntityId);
                _context.AddRange(tags);
            }

            _context.Add(feedItem);

            await _context.SaveChangesAsync();
            return feedItem.EntityId;
        }

        public async Task<string> CreatePage(CreatePageViewModel model, string userId, string feedName = null)
        {
            var page = new Page(model.Name, model.FeedEnabled)
            {
                Content = model.Content,
                Name = model.Name,
                IsActiveVersion = true
            };
            if (model.FeedEnabled && !string.IsNullOrEmpty(feedName))
            {
                var feed = new Feed(page.EntityId, feedName);
                _context.Add(feed);
            }

            _context.Add(page);

            await _context.SaveChangesAsync();
            return page.EntityId;
        }

        public Task CreateTags(IList<string> tags, string feedItemId, string userId)
        {
            var tagsToCreate = tags.AsTagsEnumerable(feedItemId);

            _context.AddRange(tagsToCreate);

            return _context.SaveChangesAsync();
        }

        public async Task<string> CreateUser(CreateUserViewModel model)
        {
            var user = new User(model.IdentityUserId)
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            _context.Add(user);

            await _context.SaveChangesAsync();
            return user.EntityId;
        }
    }
}