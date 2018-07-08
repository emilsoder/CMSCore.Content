namespace CMSCore.Content.Data.Models
{
    public class Comment : EntityBase
    {
        public Comment()
        {
        }

        public Comment(string feedItemId, string text, string fullName)
        {
            FeedItemId = feedItemId;
            FullName = fullName;
            Content = new Content(text);
        }

        public virtual FeedItem FeedItem { get; set; }
        public string FeedItemId { get; set; }

        public string FullName { get; set; }


        public string ContentId { get; set; }
        public virtual Content Content { get; set; }
    }
}