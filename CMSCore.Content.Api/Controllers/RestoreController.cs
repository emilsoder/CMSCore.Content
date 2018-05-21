namespace CMSCore.Content.Api.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
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

     [Route("api/content/restore")]
    [Produces("application/json")]
    [Authorize("contributor")]
    public class RestoreController : Controller
    {
        private readonly IClusterClient _client;

        public RestoreController(IClusterClient client) => _client = client;

        private IRestoreContentGrain _recyclebinGrain => _client.GetGrain<IRestoreContentGrain>(GrainUserId);
        private string GrainUserId => User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        [HttpPut("[action]/{feedItemId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType( 400)]
        public async Task<IActionResult> CommentsByFeedItemId( [Required] string feedItemId)
        {
            try
            {
                return Json(await _recyclebinGrain.RestoreCommentsFromRecycleBinByFeedItemId(feedItemId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType( 400)]
        public async Task<IActionResult> Feed( [Required] string entityId)
        {
            try
            {
                return Json(await _recyclebinGrain.RestoreOneFeedFromRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{pageId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType( 400)]
        public async Task<IActionResult> FeedByPageId( [Required] string pageId)
        {
            try
            {
                return Json(await _recyclebinGrain.RestoreFeedsFromRecycleBinByPageId(pageId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType( 400)]
        public async Task<IActionResult> FeedItem( [Required] string entityId)
        {
            try
            {
                return Json(await _recyclebinGrain.RestoreOneFeedItemFromRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{feedId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType( 400)]
        public async Task<IActionResult> FeedItemsByFeedId( [Required] string feedId)
        {
            try
            {
                return Json(await _recyclebinGrain.RestoreFeedItemsFromRecycleBinByFeedId(feedId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType( 400)]
        public async Task<IActionResult> Page( [Required] string entityId)
        {
            try
            {
                return Json(await _recyclebinGrain.RestoreOnePageFromRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType( 400)]
        public async Task<IActionResult> Tag( [Required] string entityId)
        {
            try
            {
                return Json(await _recyclebinGrain.RestoreTagsFromRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{feedItemId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType( 400)]
        public async Task<IActionResult> TagsByFeedItemId( [Required] string feedItemId)
        {
            try
            {
                return Json(await _recyclebinGrain.RestoreTagsFromRecycleBinByFeedItemId(feedItemId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}