using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Posts;
using Disco.BLL.Services;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers.Posts
{
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [Route("api/user/posts")]
    public class UserPostController : Controller
    {
        private readonly IServiceManager serviceManager;

        public UserPostController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreatePostModel model) =>
             await serviceManager.PostService.CreatePostAsync(model);

        [HttpDelete("{postId:int}")]
        public async Task Delete([FromRoute] int postId) =>
            await serviceManager.PostService.DeletePostAsync(postId);

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<List<Post>>> GetAllUserPosts([FromRoute] int userId) =>
            await serviceManager.PostService.GetAllUserPosts(userId);

        [HttpGet("{userId:int}/line")]
        public async Task<ActionResult<List<Post>>> GetAllPosts([FromRoute] int userId) =>
            await serviceManager.PostService.GetAllPosts(userId);
    }
}
