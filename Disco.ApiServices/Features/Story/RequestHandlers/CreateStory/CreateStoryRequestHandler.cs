using AutoMapper;
using Disco.Business.Interfaces.Dtos.Stories.User.CreateStory;
using Disco.Business.Interfaces.Dtos.StoryImages.User.CreateStoryImage;
using Disco.Business.Interfaces.Dtos.StoryVideos.User.CreateStoryVideo;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.CreateStory
{
    public class CreateStoryRequestHandler : IRequestHandler<CreateStoryRequest, CreateStoryResponseDto>
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

        public async Task<CreateStoryResponseDto> Handle(CreateStoryRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var story = _mapper.Map<Domain.Models.Models.Story>(request.Dto);
            story.Account = user.Account;

            if (request.Dto.StoryImages != null)
                foreach (var image in request.Dto.StoryImages)
                {
                    var storyImageRequestDto = _mapper.Map<CreateStoryImageRequestDto>(image);

                    var storyImage = await _storyImageService.CreateStoryImageAsync(storyImageRequestDto);
                    storyImage.Story = story;

                    story.StoryImages.Add(storyImage);
                }

            if (request.Dto.StoryVideos != null)
                foreach (var video in request.Dto.StoryVideos)
                {
                    var storyVideoRequestDto = _mapper.Map<CreateStoryVideoRequestDto>(request.Dto);

                    var storyVideo = await _storyVideoService.CreateStoryVideoAsync(storyVideoRequestDto);
                    
                    story.StoryVideos.Add(storyVideo);
                }

            await _storyService.CreateStoryAsync(story);

            var createStoryResponseDto = _mapper.Map<CreateStoryResponseDto>(story);

            return createStoryResponseDto;
        }
    }
}
