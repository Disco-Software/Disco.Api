using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Story.RequestHandlers.CreateStory;
using Disco.ApiServices.Features.Story.RequestHandlers.DeleteStory;
using Disco.ApiServices.Features.Story.RequestHandlers.GetStories;
using Disco.ApiServices.Features.Story.RequestHandlers.GetStory;
using Disco.Business.Interfaces.Dtos.Stories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story
{
    [Route("api/user/story")]
    public class StoryController : UserController
    {
        private readonly IMediator _mediator;

        public StoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Domain.Models.Models.Story>> CreateAsync([FromForm] CreateStoryDto dto) =>
            await _mediator.Send(new CreateStoryRequest(dto));

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> DeleteAsync([FromRoute] int id) =>
            await _mediator.Send(new DeleteStoryRequest(id));

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Domain.Models.Models.Story>> GetAsync([FromRoute] int id) =>
            await _mediator.Send(new GetStoryRequest(id));

        [HttpGet("all")]
        public async Task<ActionResult<List<Domain.Models.Models.Story>>> GetStoriesAsync([FromQuery] GetAllStoriesDto dto) =>
            await _mediator.Send(new GetStoriesRequest(dto));

    }
}
