namespace CMSCore.Content.Grains.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using GrainInterfaces.Messages;

    public static class ReadContentExtensions
    {
        public static IEnumerable<PageTreeViewModel> ConvertToViewModel(this IEnumerable<Page> models)
        {
            return models.Select(x => new PageTreeViewModel()
            {
                Id = x.Id,
                Date = x.Created,
                Name = x.Name,
                NormalizedName = x.NormalizedName
            });
        }

        //public static IEnumerable<TagViewModel> ConvertToViewModel

        public static PageViewModel ConvertToViewModel(this Page model)
        {
            var feed = model.Feed;

            return new PageViewModel()
            {
                Id = model.Id,
                Feed = model.Feed.ConvertToViewModel(),
                Content = model.Content.Value,
                Name = model.Name,
                Modified = model.Modified,
                NormalizedName = model.NormalizedName,
                Date = model.Created
            };
        }

        public static FeedViewModel ConvertToViewModel(this Feed feed)
        {
            var feedVieWModel = new FeedViewModel()
            {
                Date = feed.Created,
                Id = feed.Id,
                Modified = feed.Modified,
                Name = feed.Name,
                NormalizedName = feed.NormalizedName,
                FeedItems = feed.FeedItems?.ToList().Select(x => x.ConvertToPreviewViewModel()).ToArray()
            };
            return feedVieWModel;
        }

        public static FeedItemPreviewViewModel ConvertToPreviewViewModel(this FeedItem x)
        {
            var tags = x.Tags?.ToList()?.Select(rx => new TagViewModel() { NormalizedName = rx.NormalizedName, Name = rx.Name })?.ToArray();
            return new FeedItemPreviewViewModel()
            {
                Id = x.Id,
                Date = x.Created,
                Modified = x.Modified,
                Description = x.Description,
                Title = x.Title,
                Tags = tags,
                NormalizedTitle = x.NormalizedTitle
            };
        }

        public static CommentViewModel ConvertToViewModel(this Comment c)
        {
            return new CommentViewModel()
            {
                Date = c.Created,
                Text = c.Content.Value,
                FullName = c.FullName,
                CommentId = c.Id
            };
        }

        public static TagViewModel ConvertToViewModel(this Tag tag)
        {
            return new TagViewModel(tag.Id, tag.NormalizedName, tag.Name);
        }

        public static FeedItemViewModel ConvertToViewModel(this FeedItem x)
        {
            return new FeedItemViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                Date = x.Created,
                Modified = x.Modified,
                Title = x.Title,
                NormalizedTitle = x.NormalizedTitle,
                Tags = x.Tags?.ToList()?.Select(tag => tag.ConvertToViewModel()).ToArray(),
                Content = x.Content.Value,
                FeedId = x.FeedId,
                CommentsEnabled = x.CommentsEnabled,
                Comments = x.Comments?.ToList()?.Select(c => c.ConvertToViewModel()).ToArray()
            };

        }
    }
    public static class TagExtensions
    {
        public static List<Tag> ToModels(this IList<string> tagNames)
        {
            return tagNames?.Select(tagName => new Tag()
            {
                Name = tagName,
            }).ToList();
        }
    }
}