namespace CMSCore.Content.Repository.Interfaces
{
    using System.Threading.Tasks;
    using CMSCore.Content.Models;

    public interface IRecycleBinRepository
    {
        Task EmptyRecycleBin<TEntityType>() where TEntityType : EntityBase;
        Task MoveCommentToRecycleBinByEntityId(string commentId);

        Task MoveFeedItemToRecycleBinByEntityId(string feedItemId);
        Task MoveFeedToRecycleBinByEntityId(string feedId);
        Task MovePageToRecycleBinByEntityId(string pageId);
        Task MoveTagToRecycleBinByEntityId(string tagId);
    }
}