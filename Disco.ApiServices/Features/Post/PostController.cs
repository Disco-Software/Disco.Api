using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Post.RequestHandlers.CreatePost;
using Disco.ApiServices.Features.Post.RequestHandlers.DeletePost;
using Disco.ApiServices.Features.Post.RequestHandlers.GetPosts;
using Disco.ApiServices.Features.Post.RequestHandlers.GetUserPosts;
using Disco.Business.Interfaces.Dtos.Post.User.GetCurrentUserPosts;
using Disco.Business.Interfaces.Dtos.Post.User.GetPosts;
using Disco.Business.Interfaces.Dtos.Posts;
using Disco.Business.Interfaces.Dtos.Posts.User.CreatePost;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Post
{
    [Route("api/user/posts")]
    public class PostController : UserController
    {
        private readonly IMediator _mediator;

        public PostController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CreatePostResponseDto>> CreatePostAsync([FromForm] CreatePostRequestDto dto) =>
            await _mediator.Send(new CreatePostRequest(dto));

        [HttpDelete("{postId:int}")]
        public async Task DeletePostAsync([FromRoute] int postId) =>
            await _mediator.Send(new DeletePostRequest(postId));

        [HttpGet]
        public async Task<IEnumerable<GetCurrentUserPostsResponseDto>> GetAllUserPostsAsync([FromQuery] GetAllPostsDto dto) =>
            await _mediator.Send(new GetUserPostsRequest(dto));

        [HttpGet("line")]
        public async Task<IEnumerable<GetPostsResponseDto>> GetPostsAsync([FromQuery] GetAllPostsDto dto) =>
            await _mediator.Send(new GetPostsRequest(dto));
    }
}
