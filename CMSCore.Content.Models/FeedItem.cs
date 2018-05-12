using System.Collections.Generic;

namespace CMSCore.Content.Models
{
    public class FeedItem : EntityBase
    {
        public string FeedId { get; set; }

        public FeedItem()
        {
        }

        public FeedItem(string feedId, string title, string description, string content, bool commentsEnabled)
        {
            FeedId = feedId;
            Title = title;
            Description = description;
            Content = content;
            CommentsEnabled = commentsEnabled;
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NormalizedTitle = _title.NormalizeToSlug();
            }
        }

        private string _title;

        public string NormalizedTitle { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool CommentsEnabled { get; set; } = true;
    }
}