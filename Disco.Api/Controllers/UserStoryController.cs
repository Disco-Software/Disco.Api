using Disco.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Web.Http;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Disco.BLL.Constants;
using System.Threading.Tasks;
using Disco.DAL.Entities;
using Disco.BLL.Models.Stories;
using System.Collections.Generic;

namespace Disco.Api.Controllers
{
    [Route("api/user/story")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class UserStoryController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public UserStoryController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        [Microsoft.AspNetCore.Mvc.HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateStoryModel model) =>
            await serviceManager.StoryService.CreateStoryAsync(model);

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id:int}")]
        public async Task Delete([FromRoute] int id) =>
            await serviceManager.StoryService.DeleteStoryAsync(id);

        [Microsoft.AspNetCore.Mvc.HttpGet("get/{id:int}")]
        public async Task<ActionResult<Story>> GetStory([FromRoute] int id) =>
            await serviceManager.StoryService.GetStoryAsync(id);

        [Microsoft.AspNetCore.Mvc.HttpGet("all")]
        public async Task<ActionResult<List<Story>>> GetStoriesAsync([FromQuery] GetAllStoriesModel model) =>
            await serviceManager.StoryService.GetAllStoryAsync(model);

    }
}
