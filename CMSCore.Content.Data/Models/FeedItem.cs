namespace CMSCore.Content.Data.Models
{
    using System.Collections.Generic;
    using Extensions;

    public class FeedItem : EntityBase
    {
        private string _title;

        public FeedItem()
        {
        }

        public FeedItem(string feedId, string title, string description, bool commentsEnabled)
        {
            FeedId = feedId;
            Title = title;
            Description = description;
            CommentsEnabled = commentsEnabled;
        }

        public string NormalizedTitle { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NormalizedTitle = _title.NormalizeToSlug();
            }
        }

        public bool CommentsEnabled { get; set; } = true;
        public string Description { get; set; }

        public string ContentId { get; set; }
        public virtual Content Content { get; set; }

        public string FeedId { get; set; }
        public virtual Feed Feed { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}