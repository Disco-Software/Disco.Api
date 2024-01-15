using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Business.Interfaces.Dtos.Roles.Admin.GetRoles;
using Disco.Business.Utils.Exceptions;
using Disco.Business.Utils.Guards;

namespace Disco.Business.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager, 
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _mapper = mapper;

            DefaultGuard.ArgumentNull(_userManager);
            DefaultGuard.ArgumentNull(_roleManager);
            DefaultGuard.ArgumentNull(_roleRepository);
            DefaultGuard.ArgumentNull(_mapper);
        }

        public async Task RemoveRoleAsync(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);

            if (string.IsNullOrEmpty(role?.Name))
                throw new NullReferenceException();

            await _roleManager.DeleteAsync(role ?? throw new Exception());
        }

        public async Task<List<Role>> GetAllRoles(GetRolesRequestDto dto)
        {
            return await _roleRepository.GetAll(dto.PageNumber, dto.PageSize);
        }

        public async Task ChangeAccountRoleAsync(User user, string roleName)
        {
            await _userManager.RemoveFromRoleAsync(user, user.RoleName!);

            var identityResult = await _userManager.AddToRoleAsync(user, roleName);
            if(identityResult.Errors.Count() > 0)
            {
                var errors = new Dictionary<string, string>();
                foreach (var error in identityResult.Errors)
                    errors.Add(error.Code, error.Description);

                throw new InvalidRoleException(errors);
            }
        }
    }
}
