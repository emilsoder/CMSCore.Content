namespace CMSCore.Content.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public sealed class Content : EntityBase
    {
        public Content()
        {
        }

        public Content(string textValue, bool setToActiveVersion = true)
        {
            var contentVersion = new ContentVersion()
            {
                Value = textValue
            };
            if (ContentVersions == null)
            {
                ContentVersions = new List<ContentVersion>();
            }

            ContentVersions.Add(contentVersion);

            if (setToActiveVersion)
            {
                ActiveContentVersionId = contentVersion.Id;
            }
        }

        public string ActiveContentVersionId { get; set; }
        public ICollection<ContentVersion> ContentVersions { get; set; }

        [NotMapped]
        public ContentVersion ActiveContentVersion
        {
            get
            {
                var activeVersion = ContentVersions?.FirstOrDefault(x => x.Id == ActiveContentVersionId);
                return activeVersion;
            }
        }

        [NotMapped]
        public string Value
        {
            get
            {
                var activeVersion = ContentVersions?.FirstOrDefault(x => x.Id == ActiveContentVersionId);
                return activeVersion?.Value;
            }
        }
    }
}