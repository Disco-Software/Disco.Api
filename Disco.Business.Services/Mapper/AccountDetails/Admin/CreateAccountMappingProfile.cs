using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.CreateAccount;

namespace Disco.Business.Services.Mapper.AccountDetails.Admin
{
    public class CreateAccountMappingProfile : Profile
    {
        public CreateAccountMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, CreateAccountResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x));
        }
    }
}
