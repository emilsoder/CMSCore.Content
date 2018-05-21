namespace CMSCore.Content.Models
{
    public class Comment : EntityBase
    {
        public Comment() { }

        public Comment(string feedItemId, string text, string fullName)
        {
            FeedItemId = feedItemId;
            Text = text;
            FullName = fullName;
        }

        public string FeedItemId { get; set; }
        public string FullName { get; set; }

        public string Text { get; set; }
    }
}