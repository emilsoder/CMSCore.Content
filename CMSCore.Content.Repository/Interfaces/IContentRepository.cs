namespace CMSCore.Content.Repository.Interfaces
{
    public interface IContentRepository  
    {
        IRecycleBinRepository RecycleBinRepository { get;  }
        IDeleteContentRepository DeleteContentRepository { get; }
        ICreateContentRepository CreateContentRepository { get; }
        IUpdateContentRepository UpdateContentRepository { get; }
        IReadContentRepository ReadContentRepository { get; }
    }
}