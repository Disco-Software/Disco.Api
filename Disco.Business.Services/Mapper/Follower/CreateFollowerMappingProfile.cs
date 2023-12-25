using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.CreateFollower;

namespace Disco.Business.Services.Mapper.Follower
{
    public class CreateFollowerMappingProfile : Profile
    {
        public CreateFollowerMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, Domain.Models.Models.UserFollower>()
                .ForMember(x => x.Id, options => options.Ignore())
                .ForMember(x => x.FollowerAccount, options => options.MapFrom(x => x.Account))
                .ForMember(x => x.FollowerAccountId, options => options.MapFrom(x => x.AccountId))
                .ForMember(x => x.FollowingAccount, options => options.Ignore())
                .ForMember(x => x.FollowingAccountId, options => options.Ignore())
                .ForMember(x => x.IsFollowing, options => options.Ignore());

            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<AccountDto, CreateFollowerResponseDto>()
                .ForMember(x => x.Follower, options => options.MapFrom(x => x))
                .ForMember(x => x.Following, options => options.Ignore())
                .ForMember(x => x.IsFollowing, options => options.MapFrom(x => true));
        }
    }
}
