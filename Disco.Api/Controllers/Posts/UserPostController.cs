using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers.Posts
{
    [Authorize]
    [ApiController]
    [Route("api/user/posts")]
    public class UserPostController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public UserPostController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PostModel model)
        {
            var post = await serviceManager.PostService.CreatePostAsync(model);
            return Ok(post);
        }

        [HttpDelete("{postId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int postId)
        {
            await serviceManager.PostService.DeletePostAsync(postId);
            return Ok("This post was removed");
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetAllUserPosts([FromRoute] int userId)
        {
            var posts = await serviceManager.PostService.GetAllPostsAsync(e => e.UserId == userId);
            return Ok(posts);
        }
    }
}
