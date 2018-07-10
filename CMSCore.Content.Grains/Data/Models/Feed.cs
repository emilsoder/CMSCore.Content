namespace CMSCore.Content.Grains.Data.Models
{
    using System.Collections.Generic;
    using Extensions;

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

        public string PageId { get; set; }
        public virtual Page Page { get; set; }

        public virtual ICollection<FeedItem> FeedItems { get; set; }
    }
}