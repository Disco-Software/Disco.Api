using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Account;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Disco.Business.Interfaces.Dtos.AccountDetails;
using System.Linq;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;
using Disco.Domain.Interfaces.Interfaces;

namespace Disco.Business.Services.Services
{
    public class AccountDetailsService : IAccountDetailsService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAccountStatusRepository _accountStatusRepository;
        private readonly IFollowerRepository _followerRepository;

        public AccountDetailsService(
            BlobServiceClient blobServiceClient,
            IAccountRepository accountRepository,
            IAccountStatusRepository accountStatusRepository,
            IUserRepository userRepository,
            IFollowerRepository followerRepository)
        {
            _blobServiceClient = blobServiceClient;
            _accountRepository = accountRepository;
            _accountStatusRepository = accountStatusRepository;
            _userRepository = userRepository;
            _followerRepository = followerRepository;
        }

        public async Task<User> ChengePhotoAsync(User user, IFormFile formFile)
        {
            var unequeName = Guid.NewGuid().ToString() + "_" + formFile.Name.Replace(" ", "_");

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClient = blobContainerClient.GetBlobClient(unequeName);

            using var stream = formFile.OpenReadStream();
            blobClient.Upload(stream);

            user.Account.Photo = blobClient.Uri.AbsoluteUri ?? user.Account.Photo;

            await _accountRepository.Update(user.Account);

            return user;
        }

        public async Task<List<Account>> GetAccountsByNameAsync(string search)
        {
            var accounts = await _accountRepository.GetAll()
                .Where(account => account.User.UserName.StartsWith(search))
                .ToListAsync();

            foreach (var account in accounts.ToList())
            {
                if (accounts.Where(a => a.Id == account.Id).ToList().Count > 1)
                {
                    accounts.Remove(account);
                    continue;
                }
            }

            return accounts;
        }

        public async Task RemoveAsync(Account account)
        {
           await _accountRepository.Remove(account);
        }

        public async Task<UserDetailsResponseDto> GetUserDatailsAsync(User user)
        {
            user.Account.AccountStatus = await _accountStatusRepository.GetAsync(user.Account.Following.Count);

            UserDetailsResponseDto userDetailsResponseDto = new UserDetailsResponseDto();
            userDetailsResponseDto.User = user;

            return userDetailsResponseDto;
        }
    }
}
