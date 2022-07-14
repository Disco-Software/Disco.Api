using Disco.BLL.Models.Roles;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IAdminRoleService
    {
        Task<IActionResult> CreateRoleAsync(CreateRoleModel model);
        Task<IActionResult> RemoveRoleAsync(string name);
        Task<ActionResult<List<Role>>> GetAllRoles(GetAllRolesModel model);
    }
}
