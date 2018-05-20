using System;
using System.ComponentModel.DataAnnotations;

namespace CMSCore.Content.ViewModels
{
    public class CommentViewModel
    {
        public string CommentId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string FullName { get; set; }
    }

    public class CreateCommentViewModel
    {

        [Required(ErrorMessage = nameof(FeedItemId) + " is required")]
        public string FeedItemId { get; set; }

        [Required(ErrorMessage = nameof(Text) + " is required"),
         MinLength(5, ErrorMessage = "Text must be longer than 5 characters")]
        public string Text { get; set; }

        [Required(ErrorMessage = nameof(FullName) + " is required")]
        public string FullName { get; set; }
    }
}