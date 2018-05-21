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

        private IUpdateContentGrain _updateContentGrain => _client.GetGrain<IUpdateContentGrain>(GrainUserId);

        private string GrainUserId => User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        [HttpPut("[action]")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Feed(UpdateFeedViewModel model)
        {
            try
            {
                return Json(await _updateContentGrain.UpdateFeed(model, model.EntityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> FeedItem(UpdateFeedItemViewModel model)
        {
            try
            {
                return Json(await _updateContentGrain.UpdateFeedItem(model, model.EntityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Page(UpdatePageViewModel model)
        {
            try
            {
                return Json(await _updateContentGrain.UpdatePage(model, model.EntityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Tag(string tagName, string entityId)
        {
            try
            {
                return Json(await _updateContentGrain.UpdateTag(tagName, entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}