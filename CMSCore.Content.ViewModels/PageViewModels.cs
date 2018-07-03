﻿namespace CMSCore.Content.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    #region Read

    [Orleans.Concurrency.Immutable]
    public class PageViewModel
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Id { get; set; }

        public FeedViewModel Feed { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }

    [Orleans.Concurrency.Immutable]
    public class PageTreeViewModel
    {
          public string Id { get; set; }
      public DateTime Date { get; set; }

        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }

    #endregion

    #region Write 

    public class UpdatePageViewModel
    {
        [Required(ErrorMessage = nameof(Content) + " is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = nameof(Id) + " is required")]
        public string Id { get; set; }

        [Required(ErrorMessage = nameof(FeedEnabled) + " is required")]
        public bool FeedEnabled { get; set; } = true;

        [Required(ErrorMessage = nameof(Name) + " is required")]
        public string Name { get; set; }
    }

    public class CreatePageViewModel
    {
        [Required(ErrorMessage = nameof(Content) + " is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = nameof(FeedEnabled) + " is required")]
        public bool FeedEnabled { get; set; } = true;

        [Required(ErrorMessage = nameof(Name) + " is required")]
        public string Name { get; set; }
    }

    public class DeletePageViewModel
    {
        public DeletePageViewModel(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static DeletePageViewModel Initialize(string id)
        {
            return new DeletePageViewModel(id);
        }
    }

    #endregion
}