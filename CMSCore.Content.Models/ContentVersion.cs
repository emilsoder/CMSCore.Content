namespace CMSCore.Content.Models
{
    public class ContentVersion : EntityBase
    {
        public int VersionNumber { get; set; }
        public string Value { get; set; }

        public string ContentId { get; set; }
        public Content Content { get; set; }
    }
}