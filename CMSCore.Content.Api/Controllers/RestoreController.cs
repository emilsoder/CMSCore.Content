namespace CMSCore.Content.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using CMSCore.Content.Api.Extensions;
    using CMSCore.Content.GrainInterfaces;
    using CMSCore.Content.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Orleans;

    [Authorize]
    [Route("api/content/restore")]
    [Produces("application/json")]
    public class RestoreController : Controller
    {
        private readonly IClusterClient _client;

        public RestoreController(IClusterClient client) => _client = client;

        private string GrainUserId => User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        private IRestoreContentGrain _recyclebinGrain => _client.GetGrain<IRestoreContentGrain>(GrainUserId);

        [HttpPut("[action]/{entityid}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Page(string entityId)
        {
            try
            {
                return base.Json(await _recyclebinGrain.RestoreOnePageFromRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{entityid}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Feed(string entityId)
        {
            try
            {
                return base.Json(await _recyclebinGrain.RestoreOneFeedFromRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{pageId}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> FeedByPageId(string pageId)
        {
            try
            {
                return base.Json(await _recyclebinGrain.RestoreFeedsFromRecycleBinByPageId(pageId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{entityid}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> FeedItem(string entityId)
        {
            try
            {
                return base.Json(await _recyclebinGrain.RestoreOneFeedItemFromRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{feedId}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> FeedItemsByFeedId(string feedId)
        {
            try
            {
                return base.Json(await _recyclebinGrain.RestoreFeedItemsFromRecycleBinByFeedId(feedId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{entityid}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Tag(string entityId)
        {
            try
            {
                return base.Json(await _recyclebinGrain.RestoreTagsFromRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{feedItemId}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> TagsByFeedItemId(string feedItemId)
        {
            try
            {
                return base.Json(await _recyclebinGrain.RestoreTagsFromRecycleBinByFeedItemId(feedItemId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPut("[action]/{feedItemId}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> CommentsByFeedItemId(string feedItemId)
        {
            try
            {
                return base.Json(await _recyclebinGrain.RestoreCommentsFromRecycleBinByFeedItemId(feedItemId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}