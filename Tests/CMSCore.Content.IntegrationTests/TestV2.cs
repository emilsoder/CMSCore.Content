namespace CMSCore.Content.IntegrationTests
{
    using System.Collections.Generic;
    using Data;
    using Data.Configuration;
    using Data.Extensions;
    using Models;
    using Xunit;

    public class TestV2
    {
        [Fact]
        public void Add()
        {
            var context = new ContentDbContextFactory().CreateDbContext(null);

            for (int i = 2; i < 5; i++)
            {
                
            var page = new Page("page" + i, true)
            {
                Feed = new Feed()
                {
                    Name = "feed" + i,
                    NormalizedName = "feed" + i,
                    UserId = "emil",
                    FeedItems = new List<FeedItem>()
                    {
                        new FeedItem()
                        {
                            NormalizedTitle = "feeditem" + i,
                            Title = "feeditem" + i,
                            Tags = new List<Tag>(){new Tag("tag" + i) },
                            Description = "descriptiopn",
                            CommentsEnabled = true,
                            UserId = "emil",
                            Content = new Content("this is content"),
                        }
                    }
                }
            };

            context.Add(page);
            context.SaveChanges();
        }

            }
    }
}