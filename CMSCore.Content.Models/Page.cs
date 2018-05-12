using System;

namespace CMSCore.Content.Models
{
    public class Page : EntityBase
    {
        public Page()
        {
        }

        public Page(string name, bool feedEnabled)
        {
            Name = name;
            FeedEnabled = feedEnabled;
        }

        private string _name;

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

        public bool FeedEnabled { get; set; } = true;

        public string Content { get; set; }
    }
}