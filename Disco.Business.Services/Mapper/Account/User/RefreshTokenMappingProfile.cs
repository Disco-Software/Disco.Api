using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account.User.RefreshToken;

namespace Disco.Business.Services.Mapper.Account.User
{
    public class RefreshTokenMappingProfile : Profile
    {
        public RefreshTokenMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, RefreshTokenResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x));
        }
    }
}
