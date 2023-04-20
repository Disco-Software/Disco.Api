using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Disco.Business.Constants;
using System.Threading.Tasks;
using Disco.Domain.Models;
using System.Collections.Generic;
using AutoMapper;
using System;
using Disco.Business.Interfaces.Dtos.Stories;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.ApiServices.Controllers
{
    [Route("api/user/story")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _storyService;
        private readonly IStoryImageService _storyImageService;
        private readonly IStoryVideoService _storyVideoService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public StoryController(
            IStoryService storyService,
            IStoryImageService storyImageService,
            IStoryVideoService storyVideoService,
            IAccountService accountService,
            IMapper mapper)
        {
            _storyService = storyService;
            _storyImageService = storyImageService;
            _storyVideoService = storyVideoService;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateStoryDto dto)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var story = _mapper.Map<Story>(dto);

            if (dto.StoryImages != null)
                foreach (var image in dto.StoryImages)
                {
                    var storyImage = await _storyImageService.CreateStoryImageAsync(
                        new Business.Interfaces.Dtos.StoryImages.CreateStoryImageDto { StoryImageFile = image });
                    story.StoryImages.Add(storyImage);
                }

            if (dto.StoryVideos != null)
                foreach (var video in dto.StoryVideos)
                {
                    var storyImage = await _storyVideoService.CreateStoryVideoAsync(
                        new Business.Interfaces.Dtos.StoryVideos.CreateStoryVideoDto { VideoFile = video });
                    story.StoryVideos.Add(storyImage);
                }

            await _storyService.CreateStoryAsync(story);

            return Ok(story);
        }

        [HttpDelete("{id:int}")]
        public async Task Delete([FromRoute] int id)
        {
            await _storyService.DeleteStoryAsync(id);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Story>> GetStory([FromRoute] int id)
        {
            return await _storyService.GetStoryAsync(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Story>>> GetStoriesAsync([FromQuery] GetAllStoriesDto dto)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var stories = await _storyService.GetAllStoryAsync(user, dto);
            
            return stories;
        }

    }
}
