using AutoMapper;
using Disco.Business.Interfaces.Dtos.Roles.Admin.GetRoles;

namespace Disco.Business.Services.Mapper.Role.Admin
{
    public class GetRolesMappingProfile : Profile
    {
        public GetRolesMappingProfile()
        {
            CreateMap<Domain.Models.Models.Role, GetRolesResponseDto>();
        }
    }
}
