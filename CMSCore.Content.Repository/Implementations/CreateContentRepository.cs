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

        public async Task<string> CreateComment(CreateCommentViewModel model)
        {
            var comment = new Comment(model.FeedItemId, model.Text, model.FullName)
            {
             };

            _context.Add(comment);

            await _context.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<string> CreateFeedItem(CreateFeedItemViewModel model )
        {
            var feedItem = new FeedItem(model.FeedId, model.Title, model.Description,  model.CommentsEnabled)
            {
                 Tags = model.Tags?.ToModels()
            };
             
            _context.Add(feedItem);

            await _context.SaveChangesAsync();
            return feedItem.Id;
        }

        public async Task<string> CreateFeed(CreateFeedViewModel model)
        {
            if (!(await _context.Set<Page>().AnyAsync(x => x.Id == model.PageId)))
            {
                throw new Exception($"Page with id '{model.PageId}' could not be found");
            }

            if (await _context.Set<Feed>().AnyAsync(x => x.PageId == model.PageId && x.MarkedToDelete == false))
            {
                throw new Exception($"A feed already exists on page with id '{model.PageId}'");
            }

            var feed = new Feed(model.PageId, model.Name) { };
            _context.Add(feed);
            await _context.SaveChangesAsync();
            return feed.Id;
        }

        public async Task<string> CreatePage(CreatePageViewModel model, string feedName = null)
        {
            var page = new Page(model.Name, model.FeedEnabled)
            {
                 Name = model.Name,
                Content = new Content(model.Content),
             };

            if (model.FeedEnabled && !string.IsNullOrEmpty(feedName))
            {
                var feed = new Feed(page.Id, feedName)
                {
                 };
                page.Feed = feed;
            }

            _context.Add(page);

            await _context.SaveChangesAsync();
            return page.Id;
        }

        public Task CreateTags(IList<string> tags, string feedItemId)
        {
            var tagsToCreate = tags.ToModels ();

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
            return user.Id;
        }
    }
}