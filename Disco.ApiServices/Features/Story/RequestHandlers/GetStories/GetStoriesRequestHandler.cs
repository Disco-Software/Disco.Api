using AutoMapper;
using Disco.Business.Interfaces.Dtos.Stories.User.GetAllStories;
using Disco.Business.Interfaces.Dtos.StoryImages.User.GetAllStoryImages;
using Disco.Business.Interfaces.Dtos.StoryVideos.User.GetAllStoryVideos;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.GetStories
{
    public class GetStoriesRequestHandler : IRequestHandler<GetStoriesRequest, IEnumerable<GetAllStoriesResponseDto>>
    {
        private readonly IAccountService _accountService;
        private readonly IStoryService _storyService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public GetStoriesRequestHandler(
            IAccountService accountService, 
            IStoryService storyService, 
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _storyService = storyService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllStoriesResponseDto>> Handle(GetStoriesRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var stories = await _storyService.GetAllStoryAsync(user, request.Dto);

            var getAllStoriesResponseDto = _mapper.Map<IEnumerable<GetAllStoriesResponseDto>>(stories);

            return getAllStoriesResponseDto;
        }
    }
}
