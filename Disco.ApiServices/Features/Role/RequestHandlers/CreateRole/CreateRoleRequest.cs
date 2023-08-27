using Disco.Business.Interfaces.Dtos.Roles;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Role.RequestHandlers.CreateRole
{
    public class CreateRoleRequest : IRequest<Domain.Models.Models.Role>
    {
        public CreateRoleRequest(CreateRoleDto dto)
        {
            Dto = dto;
        }

        public CreateRoleDto Dto { get; }
    }
}
