using Disco.BLL.Models.Authentication;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IAdminUserService
    {
        Task<IActionResult> CreateUserAsync(RegistrationModel model);
        Task<IActionResult> RemoveUserAsync(int id);
        Task<ActionResult<List<User>>> GetAllUsers(int pageNumber, int pageSize);
    }
}
