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
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _storyService;
        private readonly IAccountService _accountService;
        public StoryController(
            IStoryService storyService,
            IAccountService accountService)
        {
            _storyService = storyService;
            _accountService = accountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateStoryDto model)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

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
            var user = await _accountService.GetAsync(HttpContext.User);

            var stories = await _storyService.GetAllStoryAsync(user, model);

            return stories;
        }

    }
}
