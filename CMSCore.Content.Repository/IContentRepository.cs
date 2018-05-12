using System.Collections.Generic;
using System.Threading.Tasks;
using CMSCore.Content.GrainInterfaces.Types;
using CMSCore.Content.Models;

namespace CMSCore.Content.Repository
{
    public interface IContentRepository :
        IReadContentRepository,
        ICreateContentRepository,
        IUpdateContentRepository,
        IDeleteContentRepository
    {
    }

    public interface IDeleteContentRepository
    {
        Task EmptyRecycleBin<TEntityType>() where TEntityType : EntityBase;

        Task MoveFeedItemToRecycleBin(string feedItemId);
        Task MoveFeedToRecycleBin(string feedId);
        Task MovePageToRecycleBin(string pageId);
        Task RestoreFromRecycleBin<TEntityType>(string entityId) where TEntityType : EntityBase;
    }

    public interface ICreateContentRepository
    {
        Task CreateComment(CreateCommentViewModel model, string feedItemId);
        Task CreateFeedItem(CreateFeedItemViewModel model, string feedId);
        Task CreatePage(CreatePageViewModel model);
        Task CreateUser(CreateUserViewModel model);
    }

    public interface IUpdateContentRepository
    {
        Task UpdateFeed(UpdateFeedViewModel model, string entityId);
        Task UpdateFeedItem(UpdateFeedItemViewModel model, string entityId);
        Task UpdatePage(UpdatePageViewModel model, string entityId);
        Task UpdateTag(string tagName, string entityId);
    }

    public interface IReadContentRepository
    {
        IEnumerable<CommentViewModel> GetComments(string feedItemId);
        FeedViewModel GetFeed(string pageId);
        FeedItemViewModel GetFeedItem(string feedItemId);
        IEnumerable<FeedItemViewModel> GetFeedItemHistory(string feedItemId);
        IEnumerable<FeedItemPreviewViewModel> GetFeedItems(string feedId);
        PageViewModel GetPage(string pageId);
        IEnumerable<TagViewModel> GetTags(string feedItemId);
        IEnumerable<UserViewModel> GetUsers();
    }
}