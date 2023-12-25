using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account.User.Facebook;

namespace Disco.Business.Services.Mapper.Account.User
{
    public class FacebookMappingProfile : Profile
    {
        public FacebookMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, FacebookResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x))
                .ForMember(x => x.AccessToken, options => options.Ignore())
                .ForMember(x => x.RefreshToken, options => options.Ignore());

        }
    }
}
