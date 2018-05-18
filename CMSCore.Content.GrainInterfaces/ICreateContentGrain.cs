namespace GrainInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.ViewModels;
    using Orleans;

    public interface ICreateContentGrain : IGrainWithStringKey
    {
         Task<GrainOperationResult> CreateComment(CreateCommentViewModel model, string feedItemId);
         Task<GrainOperationResult> CreateFeedItem(CreateFeedItemViewModel model, string feedId);
         Task<GrainOperationResult> CreatePage(CreatePageViewModel model, string userId);
        Task<GrainOperationResult> CreateTags(IList<string> tags, string feedItemId);
         Task<GrainOperationResult> CreateUser(CreateUserViewModel model);
    }

    public interface IDeleteContentGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> DeleteCommentByEntityId(string commentId);
         Task<GrainOperationResult> DeleteTagByEntityId(string tagId);
         Task<GrainOperationResult> DeletePageAndRelatedEntities(string entityId);
         Task<GrainOperationResult> DeleteFeedByPageId(string pageId);
         Task<GrainOperationResult> DeleteFeedByEntityId(string entityId);
         Task<GrainOperationResult> DeleteFeedItemsByFeedId(string feedId);
         Task<GrainOperationResult> DeleteOneFeedItemByEntityId(string entityId);
         Task<GrainOperationResult> DeleteTagsByFeedItemId(string feedItemId);
         Task<GrainOperationResult> DeleteCommentsByFeedItemId(string feedItemId);
    }

    public interface IUpdateContentGrain : IGrainWithStringKey
    {
        Task<GrainOperationResult> UpdateFeed(UpdateFeedViewModel model, string entityId);
        Task<GrainOperationResult> UpdateFeedItem(UpdateFeedItemViewModel model, string entityId);
        Task<GrainOperationResult> UpdatePage(UpdatePageViewModel model, string entityId);
        Task<GrainOperationResult> UpdateTag(string tagName, string entityId);
    }

    public interface IRecycleBinGrain : IGrainWithStringKey
    {
        //Task<GrainOperationResult> EmptyRecycleBin<TEntityType>() ;

        Task<GrainOperationResult> MoveFeedItemToRecycleBinByEntityId(string feedItemId);
        Task<GrainOperationResult> MoveFeedToRecycleBinByEntityId(string feedId);
        Task<GrainOperationResult> MovePageToRecycleBinByEntityId(string pageId);
        Task<GrainOperationResult> MoveTagToRecycleBinByEntityId(string tagId);
        Task<GrainOperationResult> MoveCommentToRecycleBinByEntityId(string commentId);

        //Task<GrainOperationResult> RestoreFromRecycleBin<TEntityType>(string entityId);

        Task<GrainOperationResult> RestoreOnePageFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreOneFeedFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreOneFeedItemFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreFeedsFromRecycleBinByPageId(string pageId);
        Task<GrainOperationResult> RestoreFeedItemsFromRecycleBinByFeedId(string feedId);


        Task<GrainOperationResult> RestoreCommentsFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreTagsFromRecycleBinByEntityId(string entityId);
        Task<GrainOperationResult> RestoreTagsFromRecycleBinByFeedItemId(string feedItemId);
        Task<GrainOperationResult> RestoreCommentsFromRecycleBinByFeedItemId(string feedItemId);
    }

    public interface IReadContentGrain : IGrainWithStringKey
    {
        Task<IEnumerable<CommentViewModel>> GetComments(string feedItemId);
        Task<FeedViewModel> GetFeed(string pageId);
        Task<FeedItemViewModel> GetFeedItem(string feedItemId);
        Task<IEnumerable<FeedItemViewModel>> GetFeedItemHistory(string feedItemId);
        Task<IEnumerable<FeedItemPreviewViewModel>> GetFeedItems(string feedId);
        Task<PageViewModel> GetPage(string pageId);
        Task<IEnumerable<TagViewModel>> GetTags(string feedItemId);
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<IEnumerable<PageTreeViewModel>> GetPageTree();
        Task<PageViewModel> GetPageByNormalizedName(string normalizedName); 
    }
}