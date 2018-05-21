namespace CMSCore.Content.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    #region Read

    public class FeedItemPreviewViewModel
    {
        public string EntityId { get; set; }

        public string Title { get; set; }
        public string NormalizedTitle { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime Modified { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }
    }

    public class FeedViewModel
    {
        public string EntityId { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Modified { get; set; }
        public IEnumerable<FeedItemPreviewViewModel> FeedItems { get; set; }
    }

    public class CreateTagsViewModel
    {
        [Required(ErrorMessage = nameof(FeedItemId) + " is required")]
        public string FeedItemId { get; set; }

        [Required(ErrorMessage = nameof(Tags) + " is required")]
        public IList<string> Tags { get; set; }
    }

    public class TagViewModel
    {
        public TagViewModel(string entityId, string normalizedName, string name)
        {
            EntityId = entityId;
            NormalizedName = normalizedName;
            Name = name;
        }

        public string EntityId { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }

    #endregion

    #region Write

    public class UpdateFeedViewModel
    {
        [Required(ErrorMessage = nameof(EntityId) + " is required")]
        public string EntityId { get; set; }

        [Required(ErrorMessage = nameof(Name) + " is required")]
        public string Name { get; set; }
    }


    public class DeleteFeedViewModel
    {
        public DeleteFeedViewModel(string entityId)
        {
            EntityId = entityId;
        }

        public string EntityId { get; set; }

        public static DeleteFeedViewModel Initialize(string entityId)
        {
            return new DeleteFeedViewModel(entityId);
        }
    }

    #endregion
}