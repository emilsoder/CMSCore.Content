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

        public CreateController(IClusterClient client)
        {
            _client = client;
        }

        [AllowAnonymous]
        [HttpPost("comment")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Comment([FromBody] CreateCommentViewModel model)
        {
            try
            {
                var _grain = _client.GetGrain<ICreateContentGrain>(model.FeedItemId);
                return Json(await _grain.CreateComment(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPost("feeditem")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> FeedItem([FromBody] CreateFeedItemViewModel model)
        {
            try
            {
                ICreateContentGrain _createContentGrain = _client.GetGrain<ICreateContentGrain>(model.FeedId);
                return Json(await _createContentGrain.CreateFeedItem(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPost("feed")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Feed([FromBody] CreateFeedViewModel model)
        {
            try
            {
                ICreateContentGrain _createContentGrain = _client.GetGrain<ICreateContentGrain>(model.PageId);
                return Json(await _createContentGrain.CreateFeed(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPost("page")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Page([FromBody] CreatePageViewModel model)
        {
            try
            {
                ICreateContentGrain _createContentGrain = _client.GetGrain<ICreateContentGrain>(Guid.NewGuid().ToString());

                return Json(await _createContentGrain.CreatePage(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPost("tags")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> Tags([FromBody] CreateTagsViewModel model)
        {
            try
            {
                ICreateContentGrain _createContentGrain = _client.GetGrain<ICreateContentGrain>(model.FeedItemId);

                return Json(await _createContentGrain.CreateTags(model.Tags, model.FeedItemId));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }

        [HttpPost("user")]
        [ValidateModelState]
        [ProducesResponseType(typeof(GrainOperationResult), 200)]
        public async Task<IActionResult> SystemUser([FromBody] CreateUserViewModel model)
        {
            try
            {
                ICreateContentGrain _createContentGrain = _client.GetGrain<ICreateContentGrain>(Guid.NewGuid().ToString());

                return Json(await _createContentGrain.CreateUser(model));
            }
            catch (Exception ex)
            {
                return ex.BadRequestFromException();
            }
        }
    }
}