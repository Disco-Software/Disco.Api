using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.GetFollower;

namespace Disco.Business.Services.Mapper.Follower
{
    public class GetFollowerMappingProfile : Profile
    {
        public GetFollowerMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<AccountDto, GetFollowerResponseDto>()
                .ForMember(x => x.Follower, options => options.MapFrom(x => x))
                .ForMember(x => x.Following, options => options.Ignore())
                .ForMember(x => x.IsFollowing, options => options.Ignore());
        }
    }
}
