using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.GetFollowers;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Mapper.Follower
{
    public class GetFollowersMappingProfile : Profile
    {
        public GetFollowersMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<UserFollower, GetFollowersResponseDto>()
                .ForMember(x => x.Following, options => options.MapFrom(x => x.FollowingAccount))
                .ForMember(x => x.Follower, options => options.MapFrom(x => x.FollowerAccount))
                .ForMember(x => x.IsFollowing, options => options.MapFrom(x => x.IsFollowing));
        }
    }
}
