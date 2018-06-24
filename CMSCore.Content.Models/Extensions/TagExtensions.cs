namespace CMSCore.Content.Models.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class TagExtensions
    {
        public static List<Tag> ToModels(this IList<string> tagNames)
        {
            return tagNames?.Select(tagName => new Tag()
            {
                Name = tagName,
            }).ToList();
        } public static List<Tag> ToModels(this IList<string> tagNames, string feedItemId)
        {
            return tagNames?.Select(tagName => new Tag()
            {
                Name = tagName,
                FeedItemId = feedItemId
            }).ToList();
        }
    }
}