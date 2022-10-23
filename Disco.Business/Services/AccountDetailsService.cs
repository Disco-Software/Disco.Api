using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Account;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Disco.Business.Services
{
    public class AccountDetailsService : IAccountDetailsService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public AccountDetailsService(
            BlobServiceClient blobServiceClient,
            IAccountRepository accountRepository,
            IUserRepository userRepository)
        {
            _blobServiceClient = blobServiceClient;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
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
    }
}
