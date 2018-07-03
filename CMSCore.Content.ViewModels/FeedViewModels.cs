namespace CMSCore.Content.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    #region Read

     public class FeedItemPreviewViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }
        public string NormalizedTitle { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime Modified { get; set; }

        public TagViewModel[] Tags { get; set; }
    }


    public class FeedViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Modified { get; set; }
        public FeedItemPreviewViewModel[] FeedItems { get; set; }
    }

    public class UpdateTagViewModel
    {
        [Required(ErrorMessage = nameof(Id) + " is required")]
        public string Id { get; set; }

        [Required(ErrorMessage = nameof(TagName) + " is required")]
        public string TagName { get; set; }
    }

    #endregion

    #region Write

    public class CreateFeedViewModel
    {
        [Required(ErrorMessage = nameof(PageId) + " is required")]
        public string PageId { get; set; }

        [Required(ErrorMessage = nameof(Name) + " is required")]
        public string Name { get; set; }
    }

    public class UpdateFeedViewModel
    {
        [Required(ErrorMessage = nameof(Id) + " is required")]
        public string Id { get; set; }

        [Required(ErrorMessage = nameof(Name) + " is required")]
        public string Name { get; set; }
    }


    public class DeleteFeedViewModel
    {
        public DeleteFeedViewModel(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static DeleteFeedViewModel Initialize(string entityId)
        {
            return new DeleteFeedViewModel(entityId);
        }
    }

    #endregion
}