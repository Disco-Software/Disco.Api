using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Disco.Business.Constants;
using System.Threading.Tasks;
using Disco.Domain.Models;
using Disco.Business.Dto.Stories;
using System.Collections.Generic;

namespace Disco.Api.Controllers
{
    [Route("api/user/story")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class UserStoryController : ControllerBase
    {
        private readonly IStoryService storyService;

        public UserStoryController(IStoryService _storyService)
        {
            storyService = _storyService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateStoryDto model)
        {
            return await storyService.CreateStoryAsync(model);
        }

        [HttpDelete("{id:int}")]
        public async Task Delete([FromRoute] int id)
        {
            await storyService.DeleteStoryAsync(id);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Story>> GetStory([FromRoute] int id)
        {
            return await storyService.GetStoryAsync(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Story>>> GetStoriesAsync([FromQuery] GetAllStoriesDto model)
        {
            return await storyService.GetAllStoryAsync(model);
        }

    }
}
