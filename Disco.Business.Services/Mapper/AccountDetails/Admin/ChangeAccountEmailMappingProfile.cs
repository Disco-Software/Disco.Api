using AutoMapper;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountEmail;

namespace Disco.Business.Services.Mapper.AccountDetails.Admin
{
    public class ChangeAccountEmailMappingProfile : Profile
    {
        public ChangeAccountEmailMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Account, ChangeAccountEmailResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
