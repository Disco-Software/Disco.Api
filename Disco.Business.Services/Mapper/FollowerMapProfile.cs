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
                .ForMember(source => source.FollowingAccount, opt => opt.MapFrom(userFollower => userFollower.FollowingAccount))
                .ForMember(source => source.FollowerAccount, opt => opt.MapFrom(userFollower => userFollower.FollowerAccount))
                .ForMember(source => source.IsFollowing, opt => opt.MapFrom(userFollower => userFollower.IsFollowing));
            
            CreateMap<IEnumerable<UserFollower>, IEnumerable<FollowerResponseDto>>();
        }
    }
}
