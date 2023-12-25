using Disco.Business.Interfaces.Dtos.Followers.User.GetFollower;
using MediatR;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollower
{
    public class GetFollowerRequest : IRequest<GetFollowerResponseDto>
    {
        public GetFollowerRequest(int id)
        {
            Id = id;
        }
        
        public int Id { get; }
    }
}
