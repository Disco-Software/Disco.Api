using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Authentication;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AdminUserService(
            UserManager<User> userManager, 
            IUserRepository userRepository,   
            IMapper mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> CreateUserAsync(RegistrationDto model)
        {
            var user = _mapper.Map<User>(model);

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);

           await _userManager.CreateAsync(user);

            return user;
        }

        public async Task<List<User>> GetAllUsers(int pageNumber, int pageSize)
        {
            return await _userRepository.GetAllUsers(pageNumber, pageSize);
        }

        public async Task RemoveUserAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            await _userManager.DeleteAsync(user);
        }
    }
}
