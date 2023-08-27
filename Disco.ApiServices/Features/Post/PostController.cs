using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using Disco.Business.Interfaces.Dtos.Songs;
using Disco.Business.Interfaces.Dtos.Images;
using Disco.Business.Interfaces.Dtos.Videos;
using Microsoft.Extensions.Options;
using Disco.Business.Interfaces.Options;
using Disco.Business.Interfaces.Dtos.AudD;
using Disco.Business.Services;
using Disco.Business.Interfaces.Dtos.Posts;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.ApiServices.Controllers;
using MediatR;
using Disco.ApiServices.Features.Post.RequestHandlers.CreatePost;
using Disco.ApiServices.Features.Post.RequestHandlers.DeletePost;
using Disco.ApiServices.Features.Post.RequestHandlers.GetUserPosts;
using Disco.ApiServices.Features.Post.RequestHandlers.GetPosts;

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
        public async Task<ActionResult<Domain.Models.Models.Post>> CreatePostAsync([FromForm] CreatePostDto dto) =>
            await _mediator.Send(new CreatePostRequest(dto));

        [HttpDelete("{postId:int}")]
        public async Task DeletePostAsync([FromRoute] int postId) =>
            await _mediator.Send(new DeletePostRequest(postId));

        [HttpGet]
        public async Task<ActionResult<List<Domain.Models.Models.Post>>> GetAllUserPosts([FromQuery] GetAllPostsDto dto) =>
            await _mediator.Send(new GetUserPostsRequest(dto));

        [HttpGet("line")]
        public async Task<ActionResult<List<Domain.Models.Models.Post>>> GetPostsAsync([FromQuery] GetAllPostsDto dto) =>
            await _mediator.Send(new GetPostsRequest(dto));
    }
}
