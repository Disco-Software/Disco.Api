using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Apple;
using Disco.Business.Dtos.Authentication;
using Disco.Business.Dtos.EmailNotifications;
using Disco.Business.Dtos.Facebook;
using Disco.Domain.Models;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Business.Dtos.Google;
using System.Security.Claims;
using System.Collections.Generic;

namespace Disco.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public AccountService(
            UserManager<User> userManager,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }


        public async Task<User> GetByEmailAsync(string email)
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

        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _userRepository.GetUserByRefreshTokenAsync(refreshToken);
        }

        public async Task LoadInfoAsync(User user)
        {
            await _userRepository.GetUserInfosAsync(user);
        }

        public async Task<User> GetAsync(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);

            await _userRepository.GetUserInfosAsync(user);
            user.RoleName = _userRepository.GetUserRole(user);

            return user;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            await _userRepository.GetUserInfosAsync(user);
            user.RoleName = _userRepository.GetUserRole(user);

            return user;
        }

        public async Task<User> CreateAsync(User user)
        {
            var identityReesult = await _userManager.CreateAsync(user);
            if(identityReesult != null)
            {
                throw new Exception();
            }

            _userManager.NormalizeEmail(user.Email);
            _userManager.NormalizeName(user.NormalizedUserName);

            _userRepository.GetUserRole(user);

            return user;
        }

        public async Task<User> GetByLogInProviderAsync(string loginProvider, string providerKey)
        {
            var user = await _userManager.FindByLoginAsync(loginProvider, providerKey);
            await _userRepository.GetUserInfosAsync(user);

            _userRepository.GetUserRole(user);

            return user;
        }

        public async Task<User> GetByNameAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            
            await _userRepository.GetUserInfosAsync(user);
            user.RoleName = _userRepository.GetUserRole(user);

            return user;
        }

        public async Task<IEnumerable<User>> GetAccountsByPeriotAsync(int periot)
        {
            return await _userRepository.GetUsersByPeriotIntAsync(periot);
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName)
        {
           return await _userManager.IsInRoleAsync(user, roleName);
        }
    }
}
