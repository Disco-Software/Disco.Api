using Disco.Business.Interfaces.Dtos.Roles;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IRoleService
    {
        Task<Role> CreateRoleAsync(CreateRoleDto dto);
        Task RemoveRoleAsync(string name);
        Task<List<Role>> GetAllRoles(GetAllRolesDto dto);
    }
}
