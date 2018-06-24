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
    using global::Orleans;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/content/recycle")]
    [Produces("application/json")]
    [Authorize("contributor")]
    public class RecycleController : Controller
    {
        private readonly IClusterClient _client;

        public RecycleController(IClusterClient client) => _client = client;
 
        [HttpDelete("[action]/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Comment([Required] string entityId)
        {
            try
            {
                IRecycleBinGrain _repository = _client.GetGrain<IRecycleBinGrain>(entityId);
                return Json(await _repository.MoveCommentToRecycleBinByEntityId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpDelete("[action]/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Feed([Required] string entityId)
        {
            try
            {
                IRecycleBinGrain _repository = _client.GetGrain<IRecycleBinGrain>(entityId);

                return Json(await _repository.MoveFeedToRecycleBinByEntityId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpDelete("[action]/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> FeedItem([Required] string entityId)
        {
            try
            {
                IRecycleBinGrain _repository = _client.GetGrain<IRecycleBinGrain>(entityId);

                return Json(await _repository.MoveFeedItemToRecycleBinByEntityId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpDelete("[action]/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Page([Required] string entityId)
        {
            try
            {
                IRecycleBinGrain _repository = _client.GetGrain<IRecycleBinGrain>(entityId);

                return Json(await _repository.MovePageToRecycleBinByEntityId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpDelete("[action]/{entityid}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Tag([Required] string entityId)
        {
            try
            {
                IRecycleBinGrain _repository = _client.GetGrain<IRecycleBinGrain>(entityId);

                return Json(await _repository.MoveTagToRecycleBinByEntityId());
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}