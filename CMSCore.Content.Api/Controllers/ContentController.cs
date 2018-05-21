namespace CMSCore.Content.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
            _grainKey = Guid.NewGuid();
            _client = client;
        }

        [HttpGet("feed/{id}")]
        [ProducesResponseType(typeof(FeedViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> GetFeed(string pageId)
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            var result = await readGrain.GetFeed(pageId);
            return Json(result);
        }

        [HttpGet("feeditem/{id}")]
        [ProducesResponseType(typeof(FeedItemViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> GetFeedItem(string id)
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            var result = await readGrain.GetFeedItem(id);
            return Json(result);
        }

        [HttpGet("page/{id}")]
        [ProducesResponseType(typeof(PageViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> GetPage(string id)
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            var result = await readGrain.GetPage(id);
            return Json(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PageTreeViewModel>), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> GetPageTree()
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            var result = await readGrain.GetPageTree();
            return Json(result);
        }
    }
}