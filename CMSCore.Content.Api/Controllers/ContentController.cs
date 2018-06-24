namespace CMSCore.Content.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CMSCore.Content.Api.Attributes;
    using CMSCore.Content.Api.Extensions;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Orleans;

    [Route("api/content")]
    [Produces("application/json")]
    public class ContentController : Controller
    {
        private readonly IClusterClient _client;

        public ContentController(IClusterClient client)
        {
            _client = client;
        }

        [HttpGet("feed/{pageId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(FeedViewModel), 200)]
         public async Task<IActionResult> GetFeed([Required] string pageId)
        {
            try
            {
                var readGrain = _client.GetGrain<IReadContentGrain>(pageId);
                return base.Json(await readGrain.GetFeedByPageId(pageId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpGet("feeditem/{feedItemId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(FeedItemViewModel), 200)]
         public async Task<IActionResult> GetFeedItem([Required] string feedItemId)
        {
            try
            {
                var readGrain = _client.GetGrain<IReadContentGrain>(feedItemId);
                return base.Json(await readGrain.GetFeedItemById(feedItemId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpGet("page/{pageId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(PageViewModel), 200)]
         public async Task<IActionResult> GetPage([Required] string pageId)
        {
            try
            {
                var readGrain = _client.GetGrain<IReadContentGrain>(pageId);
                return base.Json(await readGrain.FindPageById(pageId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PageTreeViewModel>), 200)]
         public async Task<IActionResult> GetPageTree()
        {
            try
            {
                var readGrain = _client.GetGrain<IReadContentGrain>(Guid.NewGuid().ToString());
                return base.Json(await readGrain.GetPageTree());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}