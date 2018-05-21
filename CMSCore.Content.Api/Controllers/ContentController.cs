namespace CMSCore.Content.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CMSCore.Content.Api.Attributes;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Orleans;

    [Route("api/content")]
    [Produces("application/json")]
    public class ContentController : Controller
    {
        private readonly IClusterClient _client;
        private readonly Guid _grainKey;

        public ContentController(IClusterClient client)
        {
            _grainKey = Guid.Empty;
            _client = client;
        }

        [HttpGet("feed/{pageId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(FeedViewModel), 200)]
        public async Task<IActionResult> GetFeed([Required] string pageId)
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            return base.Json(await readGrain.GetFeed(pageId));
        }

        [HttpGet("feeditem/{feedItemId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(FeedItemViewModel), 200)]
        public async Task<IActionResult> GetFeedItem([Required] string feedItemId)
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            return base.Json(await readGrain.GetFeedItem(feedItemId));
        }

        [HttpGet("page/{pageId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(PageViewModel), 200)]
        public async Task<IActionResult> GetPage([Required] string pageId)
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            return base.Json(await readGrain.GetPage(pageId));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PageTreeViewModel>), 200)]
        public async Task<IActionResult> GetPageTree()
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            return base.Json(await readGrain.GetPageTree());
        }
    }
}