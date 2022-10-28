using AutoMapper;
using Disco.Business.Dtos.Account;
using Disco.Business.Dtos.Facebook;
using Disco.Business.Dtos.Friends;
using Disco.Business.Dtos.Google;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Mapper
{
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile()
        {
            CreateMap<RegistrationDto, User>();
            CreateMap<User, UserResponseDto>()
                .ForMember(source => source.RefreshToken, opt => opt.Ignore())
                .ForMember(source => source.AccessToken, opt => opt.Ignore());
            CreateMap<Account, AccountDto>();
            CreateMap<FacebookDto, User>()
                .ForMember(source => source.UserName, f => f.Ignore())
                .ForMember(source => source.Email, e => e.Ignore());
            CreateMap<GoogleLogInDto, User>();
            CreateMap<User, UserFollower>()
                .ForMember(f => f.FollowerAccount, opt => opt.Ignore())
                .ForMember(f => f.FollowerAccountId, opt => opt.Ignore())
                .ForMember(f => f.IsFollowing, opt => opt.Ignore())
                .ForMember(f => f.FollowingAccountId, opt => opt.Ignore())
                .ForMember(f => f.FollowingAccount, opt => opt.Ignore());
        }
    }
}
