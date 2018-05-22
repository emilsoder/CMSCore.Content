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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Orleans;

    [Route("api/content/create")]
    [Produces("application/json")]
    [Authorize("contributor")]
    public class CreateController : Controller
    {
        private readonly IClusterClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateController(IClusterClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        private ICreateContentGrain _createContentGrain => _client.GetGrain<ICreateContentGrain>(GrainUserId);

        private string GrainUserId => User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        private string UserIPAddress => _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();

        [AllowAnonymous]
        [HttpPost("[action]")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Comment([FromBody] CreateCommentViewModel model)
        {
            try
            {
                var _grain = _client.GetGrain<ICreateContentGrain>(GrainUserId ?? UserIPAddress);
                return Json(await _grain.CreateComment(model, model.FeedItemId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPost("[action]")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> FeedItem([FromBody] CreateFeedItemViewModel model)
        {
            try
            {
                return Json(await _createContentGrain.CreateFeedItem(model, model.FeedId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPost("[action]")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Page([FromBody] CreatePageViewModel model)
        {
            try
            {
                return Json(await _createContentGrain.CreatePage(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPost("[action]")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Tags([FromBody] CreateTagsViewModel model)
        {
            try
            {
                return Json(await _createContentGrain.CreateTags(model.Tags, model.FeedItemId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPost("[action]")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Users([FromBody] CreateUserViewModel model)
        {
            try
            {
                return Json(await _createContentGrain.CreateUser(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}