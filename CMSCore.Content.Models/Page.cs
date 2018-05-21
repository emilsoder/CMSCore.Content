namespace CMSCore.Content.Models
{
    using CMSCore.Content.Models.Extensions;

    public class Page : EntityBase
    {
        private string _name;

        public Page() { }

        public Page(string name, bool feedEnabled)
        {
            Name = name;
            FeedEnabled = feedEnabled;
        }

        public string Content { get; set; }

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
    }
}