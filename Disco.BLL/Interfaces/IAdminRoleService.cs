using Disco.Business.Dto.Roles;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAdminRoleService
    {
        Task<IActionResult> CreateRoleAsync(CreateRoleDto model);
        Task<IActionResult> RemoveRoleAsync(string name);
        Task<ActionResult<List<Role>>> GetAllRoles(GetAllRolesDto model);
    }
}
