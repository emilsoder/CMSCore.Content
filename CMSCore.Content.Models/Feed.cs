using System;
using System.Collections.Generic;
using CMSCore.Content.Models.Extensions;

namespace CMSCore.Content.Models
{
    public class Feed : EntityBase
    {
        public string PageId { get; set; }

        public Feed()
        {
        }

        public Feed(string pageId, string name)
        {
            PageId = pageId;
            Name = name;
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
    }
}