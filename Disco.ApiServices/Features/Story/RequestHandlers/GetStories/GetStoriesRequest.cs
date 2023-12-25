using Disco.Business.Interfaces.Dtos.Stories.User.GetAllStories;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Story.RequestHandlers.GetStories
{
    public class GetStoriesRequest : IRequest<IEnumerable<GetAllStoriesResponseDto>>
    {
        public GetStoriesRequest(GetAllStoriesRequestDto dto)
        {
            Dto = dto;
        }

        public GetAllStoriesRequestDto Dto { get; }
    }
}
