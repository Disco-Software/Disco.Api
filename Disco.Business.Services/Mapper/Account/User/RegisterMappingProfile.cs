using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account.User.Register;

namespace Disco.Business.Services.Mapper.Account.User
{
    public class RegisterMappingProfile : Profile
    {
        public RegisterMappingProfile()
        {
            CreateMap<RegisterRequestDto, Domain.Models.Models.User>()
                .ForMember(x => x.UserName, options => options.MapFrom(x => x.UserName))
                .ForMember(x => x.Email, options => options.MapFrom(x => x.Email));

            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, RegisterResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x))
                .ForMember(x => x.AccessToken, options => options.Ignore())
                .ForMember(x => x.RefreshToken, options => options.Ignore());

        }
    }
}
