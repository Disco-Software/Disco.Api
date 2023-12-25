using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.GetFollowing;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Mapper.Follower
{
    public class GetFollowingMappingProfile : Profile
    {
        public GetFollowingMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<UserFollower, GetFollowingResponseDto>()
                .ForMember(x => x.Follower, options => options.MapFrom(x => x.FollowerAccount))
                .ForMember(x => x.Following, options => options.MapFrom(x => x.FollowingAccount))
                .ForMember(x => x.IsFollowing, options => options.MapFrom(x => x.IsFollowing));
        }
    }
}
