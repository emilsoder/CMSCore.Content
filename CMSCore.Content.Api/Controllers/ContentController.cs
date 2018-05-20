namespace CMSCore.Content.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using Microsoft.AspNetCore.Mvc;
    using Orleans;

    [Route("api/content")]
    public class ContentController : Controller
    {
        private readonly IClusterClient _client;
        private readonly Guid _grainKey;

        public ContentController(IClusterClient client)
        {
            _grainKey = Guid.NewGuid();
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetPageTree()
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            var result = await readGrain.GetPageTree();
            return Json(result);
        }

        [HttpGet("feed/{id}")]
        public async Task<IActionResult> GetFeed(string pageId)
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            var result = await readGrain.GetFeed(pageId);
            return Json(result);
        }

        [HttpGet("feeditem/{id}")]
        public async Task<IActionResult> GetFeedItem(string id)
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            var result = await readGrain.GetFeedItem(id);
            return Json(result);
        }

        [HttpGet("page/{id}")]
        public async Task<IActionResult> GetPage(string id)
        {
            var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
            var result = await readGrain.GetPage(id);
            return Json(result);
        }
    }
}