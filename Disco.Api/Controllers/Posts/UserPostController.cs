using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
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
    //[Authorize]
    [ApiController]
    [Route("api/user/posts")]
    public class UserPostController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public UserPostController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        [HttpPost("create")]
        public async Task<PostDTO> Create([FromBody] CreatePostModel model) =>
             await serviceManager.PostService.CreatePostAsync(model);

        [HttpDelete("{postId:int}")]
        public async Task Delete([FromRoute] int postId) =>
            await serviceManager.PostService.DeletePostAsync(postId);

        [HttpGet("{userId:int}")]
        public async Task<List<Post>> GetAllUserPosts([FromRoute] int userId) =>
            await serviceManager.PostService.GetAllUserPosts(userId);
    }
}
