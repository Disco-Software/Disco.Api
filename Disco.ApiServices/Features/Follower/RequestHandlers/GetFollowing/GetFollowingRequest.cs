using Disco.Business.Interfaces.Dtos.Friends;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowing
{
    public class GetFollowingRequest : IRequest<List<UserFollower>>
    {
        public GetFollowingRequest(GetFollowersDto dto)
        {
            Dto = dto;
        }

        public GetFollowersDto Dto { get; }
    }
}
