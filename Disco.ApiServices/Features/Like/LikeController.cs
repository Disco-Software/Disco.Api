using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Like.RequestHandlers.CreateLike;
using Disco.ApiServices.Features.Like.RequestHandlers.RemoveLike;
using Disco.Business.Interfaces.Dtos.Like.User.CreateLike;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<CreateLikeResponseDto>> CreateLikeAsync([FromQuery] int postId) =>
            await _mediator.Send(new CreateLikeRequest(postId));

        [HttpDelete("remove")]
        public async Task RemoveLikeAsync([FromQuery] int postId) =>
            await _mediator.Send(new RemoveLikeRequest(postId));
    }
}
