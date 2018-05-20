using System;
using System.ComponentModel.DataAnnotations;

namespace CMSCore.Content.ViewModels
{
    #region Read

    public class PageViewModel
    {
        public string EntityId { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public FeedViewModel Feed { get; set; }
        public DateTime Modified { get; set; }
    }

    public class PageTreeViewModel
    {
        public string EntityId { get; set; }
        public DateTime Date { get; set; }

        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }

    #endregion

    #region Write 

    public class UpdatePageViewModel
    {
        [Required(ErrorMessage = nameof(EntityId) + " is required")]
        public string EntityId { get; set; }

        [Required(ErrorMessage = nameof(Name) + " is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = nameof(Content) + " is required")]
        public string Content { get; set; } 

        [Required(ErrorMessage = nameof(FeedEnabled) + " is required")]
        public bool FeedEnabled { get; set; } = true;
    }

    public class CreatePageViewModel
    {
        [Required(ErrorMessage = nameof(Name) + " is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = nameof(Content) + " is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = nameof(FeedEnabled) + " is required")]
        public bool FeedEnabled { get; set; } = true;
    }

    public class DeletePageViewModel
    {
        public DeletePageViewModel(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static DeletePageViewModel Initialize(string id) => new DeletePageViewModel(id);
    }

    #endregion
}