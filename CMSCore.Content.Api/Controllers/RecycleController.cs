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
    [Route("api/content/recycle")]
    [Produces("application/json")]
    public class RecycleController : Controller
    {
        private readonly IClusterClient _client;

        public RecycleController(IClusterClient client)
        {
            _client = client;
        }

        private string GrainUserId => User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        private IRecycleBinGrain _repository => _client.GetGrain<IRecycleBinGrain>(GrainUserId);

        [HttpDelete("[action]/{entityid}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> FeedItem(string entityId)
        {
            try
            {
                return base.Json(await _repository.MoveFeedItemToRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpDelete("[action]/{entityid}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Feed(string entityId)
        {
            try
            {
                return base.Json(await _repository.MoveFeedToRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpDelete("[action]/{entityid}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Page(string entityId)
        {
            try
            {
                return base.Json(await _repository.MovePageToRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpDelete("[action]/{entityid}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Tag(string entityId)
        {
            try
            {
                return base.Json(await _repository.MoveTagToRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpDelete("[action]/{entityid}")]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> Comment(string entityId)
        {
            try
            {
                return base.Json(await _repository.MoveCommentToRecycleBinByEntityId(entityId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}