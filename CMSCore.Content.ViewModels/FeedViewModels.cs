using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMSCore.Content.ViewModels
{
    #region Read

    public class FeedItemPreviewViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }
        public string NormalizedTitle { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
        public DateTime Modified { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }
    }

    public class FeedViewModel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }

        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public IEnumerable<FeedItemPreviewViewModel> FeedItems { get; set; }
        public DateTime Modified { get; set; }
    }

    public class TagViewModel
    {
        public TagViewModel(string id, string normalizedName, string name)
        {
            Id = id;
            NormalizedName = normalizedName;
            Name = name;
        }

        public string Id { get; set; }
        public string NormalizedName { get; set; }
        public string Name { get; set; }
    }

    #endregion

    #region Write

    public class UpdateFeedViewModel
    {
        [Required(ErrorMessage = nameof(Id) + " is required")]
        public string Id { get; set; }

        [Required(ErrorMessage = nameof(Name) + " is required")]
        public string Name { get; set; }
    }


    public class DeleteFeedViewModel
    {
        public DeleteFeedViewModel(string entityId)
        {
            Id = entityId;
        }

        public string Id { get; set; }

        public static DeleteFeedViewModel Initialize(string entityId) => new DeleteFeedViewModel(entityId);
    }

    #endregion
}