using System.Collections.Generic;
using System.Linq;

namespace CMSCore.Content.Models.Extensions
{
    public static class TagExtensions
    {
        public static IEnumerable<Tag> AsTagsEnumerable(this IList<string> tagNames, string feedItemId)
        {
            return tagNames?.Select(tagName => new Tag(feedItemId, tagName));
        }
    }
}