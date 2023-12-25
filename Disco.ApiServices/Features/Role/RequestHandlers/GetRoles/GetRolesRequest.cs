using Disco.Business.Interfaces.Dtos.Roles.Admin.GetRoles;
using MediatR;
using System.Collections.Generic;

namespace Disco.ApiServices.Features.Role.RequestHandlers.GetRoles
{
    public class GetRolesRequest : IRequest<IEnumerable<GetRolesResponseDto>>
    {
        public GetRolesRequest(GetRolesRequestDto dto)
        {
            Dto = dto;
        }

        public GetRolesRequestDto Dto { get; }
    }
}
