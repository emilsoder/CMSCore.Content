namespace CMSCore.Content.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Threading.Tasks;
    using CMSCore.Content.Data;
    using CMSCore.Content.Models;
    using CMSCore.Content.Models.Extensions;
    using CMSCore.Content.Repository.Interfaces;
    using CMSCore.Content.ViewModels;
    using Microsoft.EntityFrameworkCore;

    public class CreateContentRepository : ICreateContentRepository
    {
        private readonly ContentDbContext _context;

        public CreateContentRepository(ContentDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateComment(CreateCommentViewModel model, string userId)
        {
            var comment = new Comment(model.FeedItemId, model.Text, model.FullName)
            {
                UserId = userId
            };

            _context.Add(comment);

            await _context.SaveChangesAsync();
            return comment.EntityId;
        }

        public async Task<string> CreateFeedItem(CreateFeedItemViewModel model, string userId)
        {
            var feedItem = new FeedItem(model.FeedId, model.Title, model.Description, model.Content, model.CommentsEnabled)
            {
                UserId = userId
            };

            if (model.Tags != null && model.Tags.Any())
            {
                var tags = model.Tags.AsTagsEnumerable(feedItem.EntityId, userId);
                _context.AddRange(tags);
            }

            _context.Add(feedItem);

            await _context.SaveChangesAsync();
            return feedItem.EntityId;
        }

        public async Task<string> CreateFeed(CreateFeedViewModel model, string userId)
        {
            if (!(await _context.Pages.AnyAsync(x => x.EntityId == model.PageId)))
            {
                throw new Exception($"Page with id '{model.PageId}' could not be found");
            }

            if (await _context.Feeds.AnyAsync(x => x.PageId == model.PageId && x.MarkedToDelete == false))
            {
                throw new Exception($"A feed already exists on page with id '{model.PageId}'");
            }

            var feed = new Feed(model.PageId, model.Name) { UserId = userId };
            _context.Add(feed);
            await _context.SaveChangesAsync();
            return feed.EntityId;
        }

        public async Task<string> CreatePage(CreatePageViewModel model, string userId, string feedName = null)
        {
            var page = new Page(model.Name, model.FeedEnabled)
            {
                Content = model.Content,
                Name = model.Name,
                IsActiveVersion = true,
                UserId = userId
            };

            if (model.FeedEnabled && !string.IsNullOrEmpty(feedName))
            {
                var feed = new Feed(page.EntityId, feedName)
                {
                    UserId = userId
                };

                _context.Add(feed);
            }

            _context.Add(page);

            await _context.SaveChangesAsync();
            return page.EntityId;
        }

        public Task CreateTags(IList<string> tags, string feedItemId, string userId)
        {
            var tagsToCreate = tags.AsTagsEnumerable(feedItemId, userId);

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