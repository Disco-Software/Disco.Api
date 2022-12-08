using AutoMapper;
using Disco.Business.Dtos.Followers;
using Disco.Business.Dtos.Friends;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Mapper
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
