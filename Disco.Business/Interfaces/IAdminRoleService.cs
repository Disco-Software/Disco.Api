using Disco.Business.Dtos.Roles;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAdminRoleService
    {
        Task<Role> CreateRoleAsync(CreateRoleDto dto);
        Task RemoveRoleAsync(string name);
        Task<List<Role>> GetAllRoles(GetAllRolesDto dto);
    }
}
