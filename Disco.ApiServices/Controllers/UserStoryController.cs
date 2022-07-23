using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Disco.Business.Constants;
using System.Threading.Tasks;
using Disco.Domain.Models;
using Disco.Business.Dtos.Stories;
using System.Collections.Generic;

namespace Disco.ApiServices.Controllers
{
    [Route("api/user/story")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class UserStoryController : ControllerBase
    {
        private readonly IStoryService _storyService;
        private readonly IUserService _userService;
        public UserStoryController(
            IStoryService storyService,
            IUserService userService)
        {
            this._storyService = storyService;
            this._userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateStoryDto model)
        {
            var user = await _userService.GetUserAsync(HttpContext.User);

           var story = await _storyService.CreateStoryAsync(user, model);

            return Ok(story);
        }

        [HttpDelete("{id:int}")]
        public async Task Delete([FromRoute] int id)
        {
            await _storyService.DeleteStoryAsync(id);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Story>> GetStory([FromRoute] int id)
        {
            return await _storyService.GetStoryAsync(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Story>>> GetStoriesAsync([FromQuery] GetAllStoriesDto model)
        {
            var user = await _userService.GetUserAsync(HttpContext.User);

            var stories = await _storyService.GetAllStoryAsync(user, model);

            return stories;
        }

    }
}
