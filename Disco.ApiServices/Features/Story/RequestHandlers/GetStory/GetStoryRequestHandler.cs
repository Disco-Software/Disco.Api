using AutoMapper;
using Disco.Business.Interfaces.Dtos.Stories.User.GetStory;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Story.RequestHandlers.GetStory
{
    public class GetStoryRequestHandler : IRequestHandler<GetStoryRequest, GetStoryResponseDto>
    {
        private readonly IStoryService _storyService;
        private readonly IMapper _mapper;

        public GetStoryRequestHandler(
            IStoryService storyService,
            IMapper mapper)
        {
            _storyService = storyService;
            _mapper = mapper;
        }

        public async Task<GetStoryResponseDto> Handle(GetStoryRequest request, CancellationToken cancellationToken)
        {
            var story = await _storyService.GetStoryAsync(request.Id);

            var getStoryResponseDto = _mapper.Map<GetStoryResponseDto>(story);

            return getStoryResponseDto;
        }
    }
}
