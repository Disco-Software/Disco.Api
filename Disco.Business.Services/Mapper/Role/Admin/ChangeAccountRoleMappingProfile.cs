using AutoMapper;
using Disco.Business.Interfaces.Dtos.Roles.Admin.ChangeAccountRole;

namespace Disco.Business.Services.Mapper.Role.Admin
{
    public class ChangeAccountRoleMappingProfile : Profile
    {
        public ChangeAccountRoleMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Account, ChangeAccountRoleResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
