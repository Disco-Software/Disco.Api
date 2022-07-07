using AutoMapper;
using Disco.BLL.Handlers;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Roles;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class RoleService : ApiRequestHandlerBase, IRoleService
    {
        private readonly ApiDbContext ctx;
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;

        public RoleService(
            ApiDbContext _ctx,
            RoleManager<Role> _roleManager, 
            IMapper _mapper)
        {
            this.ctx = _ctx;
            this.roleManager = _roleManager;
            this.mapper = _mapper;
        }

        public async Task<IActionResult> CreateRoleAsync(CreateRoleModel model)
        {
           var role = mapper.Map<Role>(model);
            role.Name = model.RoleName;

            var roleResult = await roleManager.CreateAsync(role);
            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);

            return Ok(role);
        }

        public async Task<IActionResult> RemoveRoleAsync(string name)
        {
            var role = await roleManager.FindByNameAsync(name);

            ctx.Roles.Remove(role);

           await ctx.SaveChangesAsync();

            return Ok($"Role: {role.Name} was removed");
        }
    }
}
