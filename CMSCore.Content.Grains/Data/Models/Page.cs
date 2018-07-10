namespace CMSCore.Content.Grains.Data.Models
{
    using Extensions;

    public class Page : EntityBase
    {
        private string _name;

        public Page()
        {
        }

        public Page(string name, bool feedEnabled)
        {
            Name = name;
            FeedEnabled = feedEnabled;
        }

        public bool FeedEnabled { get; set; } = true;

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

        public string ContentId { get; set; }
        public virtual Content Content { get; set; }

        public string FeedId { get; set; }
        public virtual Feed Feed { get; set; }
    }
}