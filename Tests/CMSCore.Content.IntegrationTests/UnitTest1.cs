using System;
using System.Collections.Generic;
using System.Linq;
using CMSCore.Content.Data;
using CMSCore.Content.Data.Extensions;
using CMSCore.Content.Models;
using CMSCore.Content.Repository;
using CMSCore.Content.ViewModels;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace CMSCore.Content.IntegrationTests
{
    /*
        [] UserId: 8f0e6608-6699-48b0-88b9-1c11887fcb09
        [] pageId: 70a9ce75-b761-49e8-98f8-5f7cedbf2e9a
        [] feedId: a186658d-727a-40e2-b1e7-6d03c5d4c673
        [] feedItemId: 9c054ffe-df0e-4fce-a36a-827ec0d9aab4
    */


    public class UnitTest1
    {
        private readonly IContentRepository _repository;
        private readonly ContentDbContext _context;
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
            _context = new ContentDbContext(ContentDbContextOptions.DefaultSqlServerOptions);
            _repository = new ContentRepository(_context);
        }

        private string _outputBuilder;

        public string OutputBuilder
        {
            get => _outputBuilder;
            set => _outputBuilder = _outputBuilder + "\n" + value;
        }


        #region Page

        private const string pageId = "70a9ce75-b761-49e8-98f8-5f7cedbf2e9a";

        [Fact]
        public void Get_Page_ById()
        {
            var page = _repository.GetPage(pageId);

            Assert.NotNull(page);

            var resultAsJson = JsonConvert.SerializeObject(page);
            _output.WriteLine(resultAsJson);
        }

        [Fact]
        public void Page_Update_ById()
        {
            var model = new UpdatePageViewModel
            {
                Content = "POOPFACE PAGE 5",
                FeedEnabled = true,
                Name = "POOPFACE PAGE 5",
                Id = pageId
            };

            _repository.UpdatePage(model, pageId).GetAwaiter().GetResult();
            Assert.True(true);
        }

        [Fact]
        public void Page_MarkAsDeleted_ById()
        {
            _repository.MovePageToRecycleBinByEntityId(pageId).GetAwaiter().GetResult();

            Assert.True(true);
        }

        [Fact]
        public void Feed_MarkAsDeleted_ById()
        {
            _repository.MoveFeedToRecycleBinByEntityId("c255a68f-3a21-4487-9774-a69601ed81da").GetAwaiter().GetResult();

            Assert.True(true);
        }

        [Fact]
        public void FeedItem_MarkAsDeleted_ById()
        {
            _repository.DeleteTagsByFeedItemId("9c054ffe-df0e-4fce-a36a-827ec0d9aab4").GetAwaiter().GetResult();

            Assert.True(true);
        } [Fact]
        public void Tag_MarkAsDeleted_ById()
        {
            _repository.DeleteTagByEntityId("1294af4c-8c48-40ce-ac79-2ecc0c136c78").GetAwaiter().GetResult();

            Assert.True(true);
        }

        [Fact]
        public void Page_Delete_ById()
        {
            _repository.DeletePageAndRelatedEntities(pageId).GetAwaiter().GetResult();

            Assert.True(true);
        }

        [Fact]
        public void Feed_Delete_ById()
        {
            _repository.DeleteFeedByEntityId("c255a68f-3a21-4487-9774-a69601ed81da").GetAwaiter().GetResult();

            Assert.True(true);
        }
        [Fact]
        public void Tags_Delete_ById()
        {
            _repository.EmptyRecycleBin<Tag>().GetAwaiter().GetResult();

            Assert.True(true);
        }  [Fact]
        public void Tag_Delete_ById()
        {
            _repository.EmptyRecycleBin<Tag>().GetAwaiter().GetResult();

            Assert.True(true);
        }

        #endregion


        [Fact] //18b33205-186d-4375-915d-2c79f327830e
        public void FeedUtem_Create()
        {
            const string feedId = "a186658d-727a-40e2-b1e7-6d03c5d4c673";
            OutputBuilder = "feedId: " + feedId;

            var feedItem = new CreateFeedItemViewModel()
            {
                Title = Mock.CatchPhrase,
                Content = Mock.Paragraph,
                CommentsEnabled = true,
                Description = Mock.Slogan,
                Tags = Mock.TagWordsArray(),
                FeedId = feedId
            };
            var feedItemId = _repository.CreateFeedItem(feedItem, feedId).GetAwaiter().GetResult();
            OutputBuilder = "feedItemId: " + feedItemId;

            _output.WriteLine(OutputBuilder);
        }

        [Fact] //18b33205-186d-4375-915d-2c79f327830e
        public void Tags_On_FeedItem_Create()
        {
            const string feedItemId = "18b33205-186d-4375-915d-2c79f327830e";

            var tags = new List<string>() {"Tag 1", "Tag 2"};

            _repository.CreateTags(tags, feedItemId).GetAwaiter().GetResult();
        }

        [Fact]
        public void CreateUserAndPageWithFeedAndFeedItems()
        {
            var user = new CreateUserViewModel()
            {
                FirstName = "Ove",
                LastName = "Sundberg",
                Email = "ove.sundberg@cmscore.com",
                IdentityUserId = Guid.NewGuid().ToString()
            };

            var userId = _repository.CreateUser(user).GetAwaiter().GetResult();
            OutputBuilder = "UserId: " + userId;
            var page = new CreatePageViewModel()
            {
                Name = Mock.Buzzword,
                Content = Mock.Paragraph,
                FeedEnabled = true
            };


            var pageId = _repository.CreatePage(page, Mock.Title).GetAwaiter().GetResult();
            OutputBuilder = "pageId: " + pageId;

            var feedId = _repository.GetPage(pageId).Feed.Id;
            OutputBuilder = "feedId: " + feedId;

            var feedItem = new CreateFeedItemViewModel()
            {
                Title = Mock.Title,
                Content = Mock.Paragraph,
                CommentsEnabled = true,
                Description = Mock.Slogan,
                Tags = Mock.TagWordsArray(),
                FeedId = feedId
            };

            var feedItemId = _repository.CreateFeedItem(feedItem, feedId).GetAwaiter().GetResult();
            OutputBuilder = "feedItemId: " + feedItemId;

            _output.WriteLine(OutputBuilder);
        }

        //[Fact]
        private void Add_User()
        {
            var user = new CreateUserViewModel()
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@cmscore.com",
                IdentityUserId = Guid.NewGuid().ToString()
            };

            _repository.CreateUser(user).GetAwaiter().GetResult();
            Assert.True(true);
        }

        [Fact]
        public void Create_Page()
        {
            var page = new CreatePageViewModel()
            {
                Name = Mock.Buzzword,
                Content = Mock.Paragraph,
                FeedEnabled = true
            };

            var pageFeedName = Mock.Title;

            _repository.CreatePage(page, pageFeedName).GetAwaiter().GetResult();
            Assert.True(true);
        }

        private string GetRandomFeedId()
        {
            var r = new Random();

            var feeds = _context.Feeds?.ToList();
            if (feeds == null) throw new Exception("No feeds available.");
            if (feeds.Count == 1) return feeds.First().EntityId;

            var feedId = feeds[r.Next(0, feeds.Count - 1)].EntityId;
            return feedId;
        }

        [Fact]
        public void Get_All_Pages()
        {
            var pages = _repository.GetAllPages();
            Assert.NotNull(pages);

            var resultAsJson = JsonConvert.SerializeObject(pages);
            _output.WriteLine(resultAsJson);
        }

        [Fact]
        public void Page_Move_To_RecycleBin_ById()
        {
            var id = "70a9ce75-b761-49e8-98f8-5f7cedbf2e9a";

            _repository.MovePageToRecycleBinByEntityId(id).GetAwaiter().GetResult();
            Assert.True(true);
        }


        [Fact]
        public void FeedItem_Move_To_RecycleBin()
        {
            const string id = "8c27f779-efef-4771-992e-02cf912b1794";
            //9f42d180-797c-475f-96a2-d2e967d828c5
            _repository.MoveFeedItemToRecycleBinByEntityId(id).GetAwaiter().GetResult();
            Assert.True(true);
        }

        [Fact]
        public void Page_Delete_Recycled()
        {
            //var id = "d5e8a2d2-3a44-4e70-848d-77de696b809d";

            //_repository.EmptyRecycleBin<Page>().GetAwaiter().GetResult();
            _repository.EmptyRecycleBin<Feed>().GetAwaiter().GetResult();
            _repository.EmptyRecycleBin<FeedItem>().GetAwaiter().GetResult();
            _repository.EmptyRecycleBin<Tag>().GetAwaiter().GetResult();
            _repository.EmptyRecycleBin<Comment>().GetAwaiter().GetResult();
            Assert.True(true);
        }

        [Fact]
        public void FeedItem_Delete_Recycled()
        {
            // var id = "8c27f779-efef-4771-992e-02cf912b1794";

            _repository.EmptyRecycleBin<FeedItem>().GetAwaiter().GetResult();
            Assert.True(true);
        }

        [Fact]
        public void Page_Restore_Recycled()
        {
            const string id = "d5e8a2d2-3a44-4e70-848d-77de696b809d";

            _repository.RestoreOnePageFromRecycleBinByEntityId(id).GetAwaiter().GetResult();
            Assert.True(true);
        }

        [Fact]
        public void Create_FeedItem()
        {
            //var feedId = GetRandomFeedId();
            var feedId = "a186658d-727a-40e2-b1e7-6d03c5d4c673";

            var feedItem = new CreateFeedItemViewModel()
            {
                Title = Mock.Title,
                Content = Mock.Paragraph,
                CommentsEnabled = true,
                Description = Mock.Slogan,
                Tags = Mock.TagWordsArray(),
                FeedId = feedId
            };

            _repository.CreateFeedItem(feedItem, feedId).GetAwaiter().GetResult();
            Assert.True(true);
        }

        //private readonly string _pageId = "d5e8a2d2-3a44-4e70-848d-77de696b809d";
        private readonly string _pageId = "70a9ce75-b761-49e8-98f8-5f7cedbf2e9a";

        [Fact]
        public void Get_Pages_Preview()
        {
            var page = _repository.GetPageTree();

            Assert.NotNull(page);

            var resultAsJson = JsonConvert.SerializeObject(page);
            _output.WriteLine(resultAsJson);
        }

        //[Fact]
        //public void Get_Page_ById()
        //{
        //    var page = _repository.GetPage(_pageId);

        //    Assert.NotNull(page);
        //    Assert.NotNull(page.Feed);
        //    Assert.NotNull(page.Feed.FeedItems);

        //    var resultAsJson = JsonConvert.SerializeObject(page);
        //    _output.WriteLine(resultAsJson);
        //}

        [Fact]
        public void Get_FeedItem_ById()
        {
            //var id = "8c27f779-efef-4771-992e-02cf912b1794";
            var id = "c1305de4-c2d0-48e8-a1bc-c858588a5221";
            var page = _repository.GetFeedItem(id);

            Assert.NotNull(page);

            var resultAsJson = JsonConvert.SerializeObject(page);
            _output.WriteLine(resultAsJson);
        }


        //a186658d-727a-40e2-b1e7-6d03c5d4c673
    }
}