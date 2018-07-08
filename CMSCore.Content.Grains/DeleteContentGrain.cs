namespace CMSCore.Content.Grains
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.Grains.Extensions;
    using Data.Models;
    using GrainInterfaces.Messages;
    using Orleans;

    public class DeleteContentGrain : Grain, IDeleteContentGrain
    {
        public DeleteContentGrain(Data.ContentDbContext context)
        {
            _context = context;
        }

        async Task<GrainOperationResult> IDeleteContentGrain.DeleteCommentByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();
                await this.DeleteCommentByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> IDeleteContentGrain._DeleteCommentsByFeedItemId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await this.DeleteCommentsByFeedItemId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> IDeleteContentGrain.DeleteFeedByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await this.DeleteFeedByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> IDeleteContentGrain.DeleteFeedByPageId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await this.DeleteFeedByPageId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> IDeleteContentGrain.DeleteFeedItemsByFeedId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await this.DeleteFeedItemsByFeedId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> IDeleteContentGrain.DeleteOneFeedItemByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await this.DeleteOneFeedItemByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> IDeleteContentGrain.DeletePageAndRelatedEntities()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await this.DeletePageAndRelatedEntities(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> IDeleteContentGrain.DeleteTagByEntityId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await this.DeleteTagByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        async Task<GrainOperationResult> IDeleteContentGrain.DeleteTagsByFeedItemId()
        {
            try
            {
                var id = this.GetPrimaryKeyString();

                await this.DeleteCommentByEntityId(id);
                return new GrainOperationResult { Successful = true, Message = "Operation executed successfully." };
            }
            catch (Exception ex)
            {
                return ex.ResultFromException();
            }
        }

        // -------------------

        private readonly CMSCore.Content.Data.ContentDbContext _context;


        Task DeleteCommentByEntityId(string commentId)
        {
            if (!_DeleteCommentByEntityId(commentId)) return Task.CompletedTask;

            return _context.SaveChangesAsync();
        }

        Task DeleteCommentsByFeedItemId(string feedItemId, bool saveChanges = true)
        {
            if (!_DeleteCommentsByFeedItemId(feedItemId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task DeleteFeedByEntityId(string entityId, bool saveChanges = true)
        {
            if (!_DeleteFeedByEntityId(entityId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task DeleteFeedByPageId(string pageId, bool saveChanges = true)
        {
            if (!_DeleteFeedByPageId(pageId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task DeleteFeedItemsByFeedId(string feedId, bool saveChanges = true)
        {
            if (!_DeleteFeedItemsByFeedId(feedId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task DeleteOneFeedItemByEntityId(string entityId, bool saveChanges = true)
        {
            if (!_DeleteOneFeedItemByEntityId(entityId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task DeletePageAndRelatedEntities(string entityId, bool saveChanges = true)
        {
            if (!_DeletePageAndRelatedEntities(entityId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        Task DeleteTagByEntityId(string tagId)
        {
            if (!_DeleteTagByEntityId(tagId)) return Task.CompletedTask;
            return _context.SaveChangesAsync();
        }

        Task DeleteTagsByFeedItemId(string feedItemId, bool saveChanges = true)
        {
            if (!_DeleteTagsByFeedItemId(feedItemId)) return Task.CompletedTask;
            return saveChanges ? _context.SaveChangesAsync() : Task.CompletedTask;
        }

        private bool _DeleteCommentByEntityId(string commentId)
        {
            var comment = _context.Set<Comment>()?.FirstOrDefault(x => x.Id == commentId);
            if (comment == null) return false;
            _context.Remove(comment);
            return true;
        }

        private bool _DeleteCommentsByFeedItemId(string feedItemId)
        {
            var comments = _context.Set<Comment>()?.Where(x => x.FeedItemId == feedItemId);
            if (comments == null || !comments.Any()) return false;
            _context.RemoveRange(comments);
            return true;
        }

        private bool _DeleteFeedByEntityId(string entityId)
        {
            var feedToDelete = _context.Set<Feed>()?.Where(x => x.Id == entityId && x.MarkedToDelete);
            if (feedToDelete == null || !feedToDelete.Any()) return false;
            _DeleteFeedItemsByFeedId(entityId);
            _context.RemoveRange(feedToDelete);
            return true;
        }

        private bool _DeleteFeedByPageId(string pageId)
        {
            var feedToDelete = _context.Set<Feed>()?.Where(x => x.PageId == pageId && x.MarkedToDelete);
            if (feedToDelete == null || !feedToDelete.Any()) return false;
            _DeleteFeedItemsByFeedId(feedToDelete.First().Id);
            _context.RemoveRange(feedToDelete);
            return true;
        }

        private bool _DeleteFeedItemsByFeedId(string feedId)
        {
            var feedItem = _context.Set<FeedItem>()?.Where(x => x.FeedId == feedId && x.MarkedToDelete);
            if (feedItem == null || !feedItem.Any()) return false;

            var feedItemId = feedItem.First().Id;

            _DeleteTagsByFeedItemId(feedItemId);
            _DeleteCommentsByFeedItemId(feedItemId);
            _context.RemoveRange(feedItem);
            return true;
        }

        private bool _DeleteOneFeedItemByEntityId(string entityId)
        {
            var feedItem = _context.Set<FeedItem>()?.Where(x => x.Id == entityId && x.MarkedToDelete);
            if (feedItem == null || !feedItem.Any()) return false;

            _DeleteTagsByFeedItemId(entityId);
            _DeleteCommentsByFeedItemId(entityId);
            _context.RemoveRange(feedItem);
            return true;
        }

        private bool _DeletePageAndRelatedEntities(string entityId)
        {
            var page = _context.Set<Page>()?.Where(x => x.Id == entityId && x.MarkedToDelete);
            if (page == null || !page.Any()) return false;

            _DeleteFeedByPageId(entityId);
            _context.RemoveRange(page);
            return true;
        }

        private bool _DeleteTagByEntityId(string tagId)
        {
            var tag = _context.Set<Tag>()?.FirstOrDefault(x => x.Id == tagId);
            if (tag == null) return false;
            _context.Remove(tag);
            return true;
        }

        private bool _DeleteTagsByFeedItemId(string feedItemId)
        {
            var tags = _context.Set<Tag>()?.Where(x => x.FeedItemId == feedItemId);
            if (tags == null || !tags.Any()) return false;
            _context.RemoveRange(tags);
            return true;
        }
    }
}