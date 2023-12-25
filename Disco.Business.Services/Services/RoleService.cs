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

namespace Disco.Business.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(
            RoleManager<Role> roleManager, 
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _mapper = mapper;
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
    }
}
