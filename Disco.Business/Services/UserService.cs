using Disco.Business.Dtos.Authentication;
using Disco.Business.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
           
            await _userRepository.GetUserInfosAsync(user);

            return user;
        }

        public string GetUserRole(User user)
        {
            return _userRepository.GetUserRole(user);
        }

        public async Task SaveRefreshTokenAsync(User user, string refreshToken)
        {
            await _userRepository.SaveRefreshTokenAsync(user, refreshToken);
        }
    }
}
