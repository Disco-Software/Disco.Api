using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers;
using Disco.Business.Interfaces.Dtos.Friends;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Services.Mappers
{
    public class FollowerMapProfile : Profile
    {
        public FollowerMapProfile()
        {
            CreateMap<CreateFollowerDto, UserFollower>()
                .ForMember(u => u.Id, o => o.Ignore());
            CreateMap<UserFollower, FollowerResponseDto>()
                .ForMember(source => source.FollowingAccount, opt => opt.Ignore())
                .ForMember(source => source.FollowerAccount, opt => opt.Ignore())
                .ForMember(source => source.IsFollowing, opt => opt.Ignore());
            CreateMap<IEnumerable<UserFollower>, IEnumerable<FollowerResponseDto>>();
        }
    }
}
