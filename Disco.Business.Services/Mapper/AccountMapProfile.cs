﻿using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Facebook;
using Disco.Business.Interfaces.Dtos.Friends;
using Disco.Business.Interfaces.Dtos.Google;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Services.Mappers
{
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile()
        {
            CreateMap<RegistrationDto, User>();
            CreateMap<User, UserResponseDto>()
                .ForMember(source => source.RefreshToken, opt => opt.MapFrom(user => user.RefreshToken))
                .ForMember(source => source.AccessToken, opt => opt.Ignore())
                .ForMember(source => source.AccessTokenExpirce, opt => opt.Ignore())
                .ForMember(source => source.User, opt => opt.MapFrom(user => user));
            CreateMap<Account, AccountDto>();
            CreateMap<FacebookDto, User>()
                .ForMember(source => source.UserName, f => f.Ignore())
                .ForMember(source => source.Email, e => e.Ignore());
            CreateMap<GoogleLogInDto, User>();
            CreateMap<User, UserFollower>()
                .ForMember(f => f.FollowerAccount, opt => opt.MapFrom(user => user))
                .ForMember(f => f.FollowerAccountId, opt => opt.MapFrom(user => user.Id))
                .ForMember(f => f.IsFollowing, opt => opt.Ignore())
                .ForMember(f => f.FollowingAccountId, opt => opt.Ignore())
                .ForMember(f => f.FollowingAccount, opt => opt.Ignore())
                .ForMember(f => f.Id, o => o.Ignore());
        }
    }
}
