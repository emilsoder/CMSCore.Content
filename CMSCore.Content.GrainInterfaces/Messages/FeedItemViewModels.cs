﻿namespace CMSCore.Content.GrainInterfaces.Messages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    #region Read

     public class FeedItemViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }
        public bool CommentsEnabled { get; set; }  

        public string Content { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }
        public string FeedId { get; set; }
        public DateTime Modified { get; set; }
        public string NormalizedTitle { get; set; }

        public TagViewModel[] Tags { get; set; } = new TagViewModel[1];
        public CommentViewModel [ ] Comments { get; set; } = new CommentViewModel[1]   ;
    }

    #endregion

    #region Write

    public class CreateFeedItemViewModel
    {
        [Required(ErrorMessage = nameof(CommentsEnabled) + " is required")]
        public bool CommentsEnabled { get; set; } = true;

        [Required(ErrorMessage = nameof(Content) + " is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = nameof(Description) + " is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = nameof(FeedId) + " is required")]
        public string FeedId { get; set; }

        [Required(ErrorMessage = nameof(IsContentMarkdown) + " is required")]
        public bool IsContentMarkdown { get; set; } = true;

        public IList<string> Tags { get; set; }

        [Required(ErrorMessage = nameof(Title) + " is required")]
        public string Title { get; set; }
    }

    public class UpdateFeedItemViewModel
    {
        [Required(ErrorMessage = nameof(CommentsEnabled) + " is required")]
        public bool CommentsEnabled { get; set; } = true;

        [Required(ErrorMessage = nameof(Content) + " is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = nameof(Description) + " is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = nameof(Id) + " is required")]
        public string Id { get; set; }

        [Required(ErrorMessage = nameof(IsContentMarkdown) + " is required")]
        public bool IsContentMarkdown { get; set; } = true;

        public IList<string> Tags { get; set; }

        [Required(ErrorMessage = nameof(Title) + " is required")]
        public string Title { get; set; }
    }

    public class DeleteFeedItemViewModel
    {
        public DeleteFeedItemViewModel(string entityId)
        {
            Id = entityId;
        }

        public string Id { get; set; }

        public static DeleteFeedItemViewModel Initialize(string entityId)
        {
            return new DeleteFeedItemViewModel(entityId);
        }
    }

    #endregion
}