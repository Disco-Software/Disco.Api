using Disco.Business.Interfaces.Dtos.Roles.Admin.GetRoles;
using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IRoleService
    {
        Task RemoveRoleAsync(string name);
        Task<List<Role>> GetAllRoles(GetRolesRequestDto dto);
        Task ChangeAccountRoleAsync(User user, string roleName);
    }
}
