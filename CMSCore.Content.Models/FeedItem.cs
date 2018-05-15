using CMSCore.Content.Models.Extensions;

namespace CMSCore.Content.Models
{
    public class FeedItem : EntityBase
    {
        private string _title;

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

        public string FeedId { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NormalizedTitle = _title.NormalizeToSlug();
            }
        }

        public string NormalizedTitle { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool CommentsEnabled { get; set; } = true;
    }
}