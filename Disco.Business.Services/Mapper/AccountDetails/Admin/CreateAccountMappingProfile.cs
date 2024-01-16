using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.CreateAccount;

namespace Disco.Business.Services.Mapper.AccountDetails.Admin
{
    public class CreateAccountMappingProfile : Profile
    {
        public CreateAccountMappingProfile()
        {
            CreateMap<CreateAccountRequestDto, Domain.Models.Models.User>()
                .ForMember(x => x.UserName, options => options.MapFrom(x => x.UserName))
                .ForMember(x => x.Email, options => options.MapFrom(x => x.Email))
                .ForMember(x => x.RoleName, options => options.MapFrom(x => x.RoleName))
                .ForMember(x => x.UserName, options => options.MapFrom(x => x.UserName))
                .ForMember(x => x.NormalizedEmail, options => options.MapFrom(x => x.Email.Normalize()))
                .ForMember(x => x.NormalizedUserName, options => options.MapFrom(x => x.UserName.Normalize()));

            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.User, UserDto>();

            CreateMap<UserDto, CreateAccountResponseDto>()
                .ForMember(x => x.User, options => options.MapFrom(x => x));
        }
    }
}
