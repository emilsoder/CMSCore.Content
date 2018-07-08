namespace CMSCore.Content.Grains
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.Grains.Extensions;
    using Data;
    using Data.Models;
    using GrainInterfaces.Messages;
    using Microsoft.EntityFrameworkCore;
    using Orleans;

    public class CreateContentGrain : Grain, ICreateContentGrain
    {
        public CreateContentGrain(ContentDbContext context)
        {
            _context = context;
        }


        async Task<GrainOperationResult> ICreateContentGrain.CreateComment(CreateCommentViewModel model)
        {
            try
            {
                await this.CreateComment(model);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> ICreateContentGrain.CreateFeedItem(CreateFeedItemViewModel model)
        {
            try
            {
                await this.CreateFeedItem(model);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> ICreateContentGrain.CreatePage(CreatePageViewModel model)
        {
            try
            {
                await this.CreatePage(model);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> ICreateContentGrain.CreateFeed(CreateFeedViewModel model)
        {
            try
            {
                await this.CreateFeed(model);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> ICreateContentGrain.CreateTags(IList<string> tags, string feedItemId)
        {
            try
            {
                await this.CreateTags(tags, feedItemId);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> ICreateContentGrain.CreateUser(CreateUserViewModel model)
        {
            try
            {
                await this.CreateUser(model);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        // ----------

        private readonly ContentDbContext _context;


        public async Task<string> CreateComment(CreateCommentViewModel model)
        {
            var comment = new Comment(model.FeedItemId, model.Text, model.FullName)
            {
            };

            _context.Add(comment);

            await _context.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<string> CreateFeedItem(CreateFeedItemViewModel model)
        {
            var feedItem = new FeedItem(model.FeedId, model.Title, model.Description, model.CommentsEnabled)
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
            var tagsToCreate = tags.ToModels();

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