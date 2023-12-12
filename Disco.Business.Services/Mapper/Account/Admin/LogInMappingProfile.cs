using AutoMapper;
using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;

namespace Disco.Business.Services.Mapper.Account.Admin
{
    public class LogInMappingProfile : Profile
    {
        public LogInMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, LogInResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x));
        }
    }
}
