using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account.User.Google;

namespace Disco.Business.Services.Mapper.Account.User
{
    public class GoogleMappingProfile : Profile
    {
        public GoogleMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, GoogleResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x));
        }
    }
}
