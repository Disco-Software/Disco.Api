using Disco.BLL.Models.Roles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IRoleService
    {
        Task<IActionResult> CreateRoleAsync(CreateRoleModel model);
        Task<IActionResult> RemoveRoleAsync(string name);
    }
}
