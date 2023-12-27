using Disco.Business.Interfaces.Dtos.Roles.Admin.ChangeAccountRole;
using MediatR;

namespace Disco.ApiServices.Features.Role.RequestHandlers.ChangeAccountRole
{
    public class ChangeAccountRoleRequest : IRequest<ChangeAccountRoleResponseDto>
    {
        public ChangeAccountRoleRequest(
            ChangeAccountRoleRequestDto changeAccountRoleRequestDto)
        {
            ChangeAccountRoleRequestDto = changeAccountRoleRequestDto;
        }

        public ChangeAccountRoleRequestDto ChangeAccountRoleRequestDto { get; }
    }
}
