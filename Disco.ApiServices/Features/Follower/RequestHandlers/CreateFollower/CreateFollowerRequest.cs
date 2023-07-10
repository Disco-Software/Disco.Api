using Disco.Business.Interfaces.Dtos.Followers;
using Disco.Business.Interfaces.Dtos.Friends;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Follower.RequestHandlers.CreateFollower
{
    public class CreateFollowerRequest : IRequest<FollowerResponseDto>
    {
        public CreateFollowerRequest(CreateFollowerDto dto)
        {
            Dto = dto;
        }

        public CreateFollowerDto Dto { get; }
    }
}
