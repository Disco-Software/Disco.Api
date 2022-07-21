using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dto.Posts;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [Route("api/user/posts")]
    public class UserPostController : Controller
    {
        private readonly IPostService postService;

        public UserPostController(IPostService _postService)
        {
            postService = _postService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreatePostDto model)
        {
            return await postService.CreatePostAsync(model);
        }

        [HttpDelete("{postId:int}")]
        public async Task Delete([FromRoute] int postId)
        {
            await postService.DeletePostAsync(postId);
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllUserPosts([FromQuery] GetAllPostsDto model)
        {
            return await postService.GetAllUserPosts(model);
        }

        [HttpGet("line")]
        public async Task<ActionResult<List<Post>>> GetAllPosts([FromQuery] GetAllPostsDto model)
        {
            return await postService.GetAllPosts(model);
        }
    }
}
