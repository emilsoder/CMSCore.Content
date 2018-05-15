using CMSCore.Content.Models.Extensions;

namespace CMSCore.Content.Models
{
    public class Feed : EntityBase
    {
        private string _name;

        public Feed()
        {
        }

        public Feed(string pageId, string name)
        {
            PageId = pageId;
            Name = name;
        }

        public string PageId { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NormalizedName = _name.NormalizeToSlug();
            }
        }

        public string NormalizedName { get; set; }
    }
}