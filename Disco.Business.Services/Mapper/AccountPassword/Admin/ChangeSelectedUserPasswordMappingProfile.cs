using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ChangeSelectedUserPassword;

namespace Disco.Business.Services.Mapper.AccountPassword.Admin
{
    public class ChangeSelectedUserPasswordMappingProfile : Profile
    {
        public ChangeSelectedUserPasswordMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<AccountDto, ChangeSelectedUserPasswordResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
