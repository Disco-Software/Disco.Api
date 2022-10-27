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
            CreateMap<CreateFollowerDto, UserFollower>();
            CreateMap<AccountDto, FollowerResponseDto>()
                .ForMember(source => source.UserAccount, opt => opt.Ignore())
                .ForMember(source => source.FollowerAccount, opt => opt.Ignore())
                .ForMember(source => source.FriendId, opt => opt.Ignore());
        }
    }
}
