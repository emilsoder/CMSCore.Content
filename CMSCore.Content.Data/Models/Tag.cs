namespace CMSCore.Content.Data.Models
{
    using Extensions;

    public class Tag : EntityBase
    {
        private string _name;

        public Tag() { }

        public Tag(string feedItemId, string name)
        {
            FeedItemId = feedItemId;
            Name = name;
        }

        public Tag(string name)
        {
            Name = name;
        }

        public string FeedItemId { get; set; }
        public virtual FeedItem FeedItem { get; set; }

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