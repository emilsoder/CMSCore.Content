namespace CMSCore.Content.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using CMSCore.Content.Api.Attributes;
    using CMSCore.Content.Api.Extensions;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Orleans;

    [Route("api/content/update")]
    [Produces("application/json")]
    [Authorize("contributor")]
    public class UpdateController : Controller
    {
        private readonly IClusterClient _client;

        public UpdateController(IClusterClient client) => _client = client;

        [HttpPut("feed")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Feed([FromBody] UpdateFeedViewModel model)
        {
            try
            {
                IUpdateContentGrain _updateContentGrain = _client.GetGrain<IUpdateContentGrain>(model.Id);
                return Json(await _updateContentGrain.UpdateFeed(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("feedItem")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> FeedItem([FromBody] UpdateFeedItemViewModel model)
        {
            try
            {
                IUpdateContentGrain _updateContentGrain = _client.GetGrain<IUpdateContentGrain>(model.Id);
                return Json(await _updateContentGrain.UpdateFeedItem(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("page")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Page([FromBody] UpdatePageViewModel model)
        {
            try
            {
                IUpdateContentGrain _updateContentGrain = _client.GetGrain<IUpdateContentGrain>(model.Id);
                return Json(await _updateContentGrain.UpdatePage(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("tag")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Tag([FromBody] UpdateTagViewModel model)
        {
            try
            {
                IUpdateContentGrain _updateContentGrain = _client.GetGrain<IUpdateContentGrain>(model.Id);
                return Json(await _updateContentGrain.UpdateTag(model.TagName, model.Id));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}