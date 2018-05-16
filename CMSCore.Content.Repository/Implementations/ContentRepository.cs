using CMSCore.Content.Repository.Interfaces;

namespace CMSCore.Content.Repository
{
    public class ContentRepository : IContentRepository
    {
        public ContentRepository(
            IRecycleBinRepository recycleBinRepository,
            IDeleteContentRepository deleteContentRepository,
            ICreateContentRepository createContentRepository,
            IUpdateContentRepository updateContentRepository,
            IReadContentRepository readContentRepository)
        {
            RecycleBinRepository = recycleBinRepository;
            DeleteContentRepository = deleteContentRepository;
            CreateContentRepository = createContentRepository;
            UpdateContentRepository = updateContentRepository;
            ReadContentRepository = readContentRepository;
        }


        public virtual IRecycleBinRepository RecycleBinRepository { get; }

        public virtual IDeleteContentRepository DeleteContentRepository { get; }

        public virtual ICreateContentRepository CreateContentRepository { get; }

        public virtual IUpdateContentRepository UpdateContentRepository { get; }

        public virtual IReadContentRepository ReadContentRepository { get; }
    }
}