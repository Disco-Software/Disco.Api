using Disco.Business.Interfaces.Dtos.Followers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollower
{
    public class GetFollowerRequest : IRequest<FollowerResponseDto>
    {
        public GetFollowerRequest(int id)
        {
            Id = id;
        }
        
        public int Id { get; }
    }
}
