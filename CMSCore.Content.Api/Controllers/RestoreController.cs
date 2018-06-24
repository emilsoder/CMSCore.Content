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

        [HttpPut("comment/{feedItemId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> CommentsByFeedItemId([Required] string feedItemId)
        {
            try
            {
                IRestoreContentGrain _recyclebinGrain = _client.GetGrain<IRestoreContentGrain>(feedItemId);
                return Json(await _recyclebinGrain.RestoreCommentsFromRecycleBinByFeedItemId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("feed/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Feed([Required] string entityId)
        {
            try
            {
                IRestoreContentGrain _recyclebinGrain = _client.GetGrain<IRestoreContentGrain>(entityId);
                return Json(await _recyclebinGrain.RestoreOneFeedFromRecycleBinByEntityId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{pageId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> FeedByPageId([Required] string pageId)
        {
            try
            {
                IRestoreContentGrain _recyclebinGrain = _client.GetGrain<IRestoreContentGrain>(pageId);
                return Json(await _recyclebinGrain.RestoreFeedsFromRecycleBinByPageId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("FeedItem/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> FeedItem([Required] string entityId)
        {
            try
            {
                IRestoreContentGrain _recyclebinGrain = _client.GetGrain<IRestoreContentGrain>(entityId);
                return Json(await _recyclebinGrain.RestoreOneFeedItemFromRecycleBinByEntityId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{feedId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> FeedItemsByFeedId([Required] string feedId)
        {
            try
            {
                IRestoreContentGrain _recyclebinGrain = _client.GetGrain<IRestoreContentGrain>(feedId);
                return Json(await _recyclebinGrain.RestoreFeedItemsFromRecycleBinByFeedId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("page/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Page([Required] string entityId)
        {
            try
            {
                IRestoreContentGrain _recyclebinGrain = _client.GetGrain<IRestoreContentGrain>(entityId);
                return Json(await _recyclebinGrain.RestoreOnePageFromRecycleBinByEntityId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("tag/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Tag([Required] string entityId)
        {
            try
            {
                IRestoreContentGrain _recyclebinGrain = _client.GetGrain<IRestoreContentGrain>(entityId);
                return Json(await _recyclebinGrain.RestoreTagsFromRecycleBinByEntityId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{feedItemId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> TagsByFeedItemId([Required] string feedItemId)
        {
            try
            {
                IRestoreContentGrain _recyclebinGrain = _client.GetGrain<IRestoreContentGrain>(feedItemId);
                return Json(await _recyclebinGrain.RestoreTagsFromRecycleBinByFeedItemId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}