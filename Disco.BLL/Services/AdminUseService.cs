using AutoMapper;
using Disco.Business.Handlers;
using Disco.Business.Interfaces;
using Disco.Business.Dto.Authentication;
using Disco.Business.Validatars;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class AdminUserService : ApiRequestHandlerBase, IAdminUserService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        public AdminUserService(
            ApiDbContext _ctx, 
            UserManager<User> _userManager, 
            IMapper _mapper)
        {
            ctx = _ctx;
            userManager = _userManager;
            mapper = _mapper;
        }

        public async Task<IActionResult> CreateUserAsync(RegistrationDto model)
        {
            var validator = await RegistrationValidator
                .Create(userManager)
                .ValidateAsync(model);

            if (validator.Errors.Count > 0)
                return BadRequest(validator.Errors);

            var user = mapper.Map<User>(model);

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);

           var identityResult = await userManager.CreateAsync(user);
            if(!identityResult.Succeeded)
                return BadRequest(identityResult);

            return Ok(user);
        }

        public async Task<ActionResult<List<User>>> GetAllUsers(int pageNumber, int pageSize) =>
            await ctx.Users
                .OrderByDescending(d => d.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        public async Task<IActionResult> RemoveUserAsync(int id)
        {
            var user = await ctx.Users
                .Include(p => p.Profile)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            ctx.Users.Remove(user);

            return Ok();
        }
    }
}
