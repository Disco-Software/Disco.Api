using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Roles;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class AdminRoleService : IAdminRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public AdminRoleService(
            RoleManager<Role> roleManager, 
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Role> CreateRoleAsync(CreateRoleDto dto)
        {
           var role = _mapper.Map<Role>(dto);
            role.Name = dto.RoleName;

            var roleResult = await _roleManager.CreateAsync(role);

            return role;
        }

        public async Task RemoveRoleAsync(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);

            await _roleManager.DeleteAsync(role);
        }

        public async Task<List<Role>> GetAllRoles(GetAllRolesDto model)
        {
            return await _roleRepository.GetAll(model.PageNumber, model.PageSize);
        }
    }
}
