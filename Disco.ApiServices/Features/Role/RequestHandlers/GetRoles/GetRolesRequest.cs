using Disco.Business.Interfaces.Dtos.Roles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Role.RequestHandlers.GetRoles
{
    public class GetRolesRequest : IRequest<List<Domain.Models.Models.Role>>
    {
        public GetRolesRequest(GetAllRolesDto dto)
        {
            Dto = dto;
        }

        public GetAllRolesDto Dto { get; }
    }
}
