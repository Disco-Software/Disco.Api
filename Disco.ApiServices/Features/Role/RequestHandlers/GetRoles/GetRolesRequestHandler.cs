using AutoMapper;
using Disco.Business.Interfaces.Dtos.Roles.Admin.GetRoles;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Role.RequestHandlers.GetRoles
{
    public class GetRolesRequestHandler : IRequestHandler<GetRolesRequest, IEnumerable<GetRolesResponseDto>>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public GetRolesRequestHandler(
            IRoleService roleService,
            IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetRolesResponseDto>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAllRoles(request.Dto);

            var getRolesResponseDto = _mapper.Map<IEnumerable<GetRolesResponseDto>>(roles.AsEnumerable());

            return getRolesResponseDto;
        }
    }
}
