using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Role.RequestHandlers.CreateRole
{
    public class CreateRoleRequestHandler : IRequestHandler<CreateRoleRequest, Domain.Models.Models.Role>
    {
        private readonly IRoleService _roleService;

        public CreateRoleRequestHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Domain.Models.Models.Role> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleService.CreateRoleAsync(request.Dto);

            return role;
        }
    }
}
