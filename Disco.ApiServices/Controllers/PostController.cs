using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Posts;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [Route("api/user/posts")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IAccountService _userService;

        public PostController(
            IPostService postService,
            IAccountService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreatePostDto model)
        {
            var user = await _userService.GetAsync(HttpContext.User);

            var post = await _postService.CreatePostAsync(user, model);

            return Ok(post);
        }

        [HttpDelete("{postId:int}")]
        public async Task Delete([FromRoute] int postId)
        {
            await _postService.DeletePostAsync(postId);
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllUserPosts([FromQuery] GetAllPostsDto model)
        {
            var user = await _userService.GetAsync(HttpContext.User);

            return await _postService.GetAllUserPosts(user, model);
        }

        [HttpGet("line")]
        public async Task<ActionResult<List<Post>>> GetAllPosts([FromQuery] GetAllPostsDto model)
        {
            var user = await _userService.GetAsync(HttpContext.User);

            var posts = await _postService.GetAllPosts(user, model);

            return posts;
        }
    }
}
