using Disco.BLL.Dto.Roles;
using Disco.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IAdminRoleService
    {
        Task<IActionResult> CreateRoleAsync(CreateRoleDto model);
        Task<IActionResult> RemoveRoleAsync(string name);
        Task<ActionResult<List<Role>>> GetAllRoles(GetAllRolesDto model);
    }
}
