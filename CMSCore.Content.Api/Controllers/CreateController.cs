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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Orleans;

    [Authorize]
    [Route("api/content/create")]
    public class CreateController : Controller
    {
        private readonly IClusterClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateController(IClusterClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            this._httpContextAccessor = httpContextAccessor;
        }

        private string GrainUserId => User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        private string UserIPAddress => _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        private ICreateContentGrain _createContentGrain => _client.GetGrain<ICreateContentGrain>(GrainUserId);

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Comment([FromBody] CreateCommentViewModel model)
        {
            try
            {
                var _grain = _client.GetGrain<ICreateContentGrain>(GrainUserId ?? UserIPAddress);
                return base.Json(await _grain.CreateComment(model, model.FeedItemId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.BadRequestFromException());
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> FeedItem([FromBody] CreateFeedItemViewModel model)
        {
            try
            {
                return base.Json(await _createContentGrain.CreateFeedItem(model, model.FeedId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.BadRequestFromException());
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Page([FromBody] CreatePageViewModel model)
        {
            try
            {
                return base.Json(await _createContentGrain.CreatePage(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.BadRequestFromException());
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Tags([FromBody] CreateTagsViewModel model)
        {
            try
            {
                return base.Json(await _createContentGrain.CreateTags(model.Tags, model.FeedItemId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.BadRequestFromException());
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Users([FromBody] CreateUserViewModel model)
        {
            try
            {
                return base.Json(await _createContentGrain.CreateUser(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}