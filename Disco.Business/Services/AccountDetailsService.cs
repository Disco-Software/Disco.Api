using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Account;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Disco.Business.Dtos.AccountDetails;
using System.Linq;

namespace Disco.Business.Services
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
            return await _accountRepository.FindAccountsByUserNameAsync(search);
        }

        public async Task RemoveAsync(Account account)
        {
           await _accountRepository.RemoveAccountAsync(account.Id);
        }

        public async Task<UserDetailsResponseDto> GetUserDatailsAsync(User user)
        {
            user.Account.Following = await _followerRepository.GetFollowingAsync(user.Id);
            user.Account.Followers = await _followerRepository.GetFollowersAsync(user.Id);

            UserDetailsResponseDto userDetailsResponseDto = new UserDetailsResponseDto();
            userDetailsResponseDto.User = user;

            return userDetailsResponseDto;
        }
    }
}
