using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Like.RequestHandlers.CreateLike;
using Disco.ApiServices.Features.Like.RequestHandlers.RemoveLike;
using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Like
{
    [Route("api/user/likes")]
    public class LikeController : UserController
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateLikeAsync([FromQuery] int postId) =>
            await _mediator.Send(new CreateLikeRequest(postId));

        [HttpDelete("remove")]
        public async Task<ActionResult<int>> RemoveLikeAsync([FromQuery] int postId) =>
            await _mediator.Send(new RemoveLikeRequest(postId));
    }
}
