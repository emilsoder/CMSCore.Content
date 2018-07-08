namespace CMSCore.Content.GrainInterfaces.Messages
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateTagsViewModel
    {
        [Required(ErrorMessage = nameof(FeedItemId) + " is required")]
        public string FeedItemId { get; set; }

        [Required(ErrorMessage = nameof(Tags) + " is required")]
        public IList<string> Tags { get; set; }
    }
}