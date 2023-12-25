using Disco.Business.Interfaces.Dtos.Stories.User.GetStory;
using MediatR;

namespace Disco.ApiServices.Features.Story.RequestHandlers.GetStory
{
    public class GetStoryRequest : IRequest<GetStoryResponseDto>
    {
        public GetStoryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
