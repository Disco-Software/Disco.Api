using Disco.Business.Interfaces.Dtos.Roles;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Services.Services;
using Disco.Domain.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Role.RequestHandlers.GetRoles
{
    public class GetRolesRequestHandler : IRequestHandler<GetRolesRequest, List<Domain.Models.Models.Role>>
    {
        private readonly IRoleService _roleService;

        public GetRolesRequestHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<List<Domain.Models.Models.Role>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            return await _roleService.GetAllRoles(request.Dto);
        }
    }
}
