using AutoMapper;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.CreateStory
{
    public class CreateStoryRequestHandler : IRequestHandler<CreateStoryRequest, Domain.Models.Models.Story>
    {
        private readonly IAccountService _accountService;
        private readonly IStoryService _storyService;
        private readonly IStoryImageService _storyImageService;
        private readonly IStoryVideoService _storyVideoService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CreateStoryRequestHandler(
            IAccountService accountService, 
            IStoryService storyService, 
            IStoryImageService storyImageService,
            IStoryVideoService storyVideoService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _storyService = storyService;
            _storyImageService = storyImageService;
            _storyVideoService = storyVideoService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<Domain.Models.Models.Story> Handle(CreateStoryRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var story = _mapper.Map<Domain.Models.Models.Story>(request.Dto);

            if (request.Dto.StoryImages != null)
                foreach (var image in request.Dto.StoryImages)
                {
                    var storyImage = await _storyImageService.CreateStoryImageAsync(
                        new Business.Interfaces.Dtos.StoryImages.CreateStoryImageDto { StoryImageFile = image });
                    story.StoryImages.Add(storyImage);
                }

            if (request.Dto.StoryVideos != null)
                foreach (var video in request.Dto.StoryVideos)
                {
                    var storyImage = await _storyVideoService.CreateStoryVideoAsync(
                        new Business.Interfaces.Dtos.StoryVideos.CreateStoryVideoDto { VideoFile = video });
                    story.StoryVideos.Add(storyImage);
                }

            await _storyService.CreateStoryAsync(story);

            return story;
        }
    }
}
