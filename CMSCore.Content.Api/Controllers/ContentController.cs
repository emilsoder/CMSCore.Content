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
        private readonly Guid _grainKey;

        public ContentController(IClusterClient client)
        {
            _grainKey = Guid.Empty;
            _client = client;
        }

        [HttpGet("feed/{pageId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(FeedViewModel), 200)]
        [ProducesResponseType(typeof(GrainOperationResult), 400)]
        public async Task<IActionResult> GetFeed([Required] string pageId)
        {
            try
            {
                var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
                return base.Json(await readGrain.GetFeed(pageId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpGet("feeditem/{feedItemId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(FeedItemViewModel), 200)]
        [ProducesResponseType(typeof(GrainOperationResult), 400)]
        public async Task<IActionResult> GetFeedItem([Required] string feedItemId)
        {
            try
            {
                var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
                return base.Json(await readGrain.GetFeedItem(feedItemId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpGet("page/{pageId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(PageViewModel), 200)]
        [ProducesResponseType(typeof(GrainOperationResult), 400)]
        public async Task<IActionResult> GetPage([Required] string pageId)
        {
            try
            {
                var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
                return base.Json(await readGrain.GetPage(pageId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PageTreeViewModel>), 200)]
        [ProducesResponseType(typeof(GrainOperationResult), 400)]
        public async Task<IActionResult> GetPageTree()
        {
            try
            {
                var readGrain = _client.GetGrain<IReadContentGrain>(_grainKey);
                return base.Json(await readGrain.GetPageTree());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}