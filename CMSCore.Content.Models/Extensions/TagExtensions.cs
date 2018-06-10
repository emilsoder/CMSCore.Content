namespace CMSCore.Content.Models.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class TagExtensions
    {
        public static IEnumerable<Tag> AsTagsEnumerable(this IList<string> tagNames, string feedItemId, string userId)
        {
            return tagNames?.Select(tagName => new Tag(feedItemId, tagName)
            {
                UserId = userId 
            });
        }
    }
}