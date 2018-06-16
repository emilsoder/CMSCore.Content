namespace CMSCore.Content.Models
{
    using System.Collections.Generic;
    using CMSCore.Content.Models.Extensions;

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

        public virtual Content Content { get; set; }

        public virtual Feed Feed { get; set; }
    }


    public sealed class Content : EntityBase
    {
        public Content()
        {
        }

        public Content(string textValue, bool setToActiveVersion = true)
        {
            var contentVersion = new ContentVersion()
            {
                TextValue = textValue
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
    }

    public class ContentVersion : EntityBase
    {
        public int VersionNumber { get; set; }
        public string TextValue { get; set; }

        public string ContentId { get; set; }
        public Content Content { get; set; }
    }
}