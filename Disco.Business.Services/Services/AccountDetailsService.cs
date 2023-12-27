using Azure.Storage.Blobs;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Http;
using Disco.Domain.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Disco.Business.Interfaces.Dtos.AccountDetails;
using System.Linq;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Disco.Business.Interfaces.Dtos.AccountDetails;
using System.Linq;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class AccountDetailsService : IAccountDetailsService
    {
        private readonly UserManager<User> _userManager;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAccountStatusRepository _accountStatusRepository;
        private readonly IFollowerRepository _followerRepository;

        public AccountDetailsService(
            UserManager<User> userManager,
            BlobServiceClient blobServiceClient,
            IAccountRepository accountRepository,
            IAccountStatusRepository accountStatusRepository,
            IUserRepository userRepository,
            IFollowerRepository followerRepository)
        {
            _userManager = userManager;
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

            await _accountRepository.UpdateAsync(user.Account);

            return user;
        }

        public async Task<List<Account>> GetAccountsByNameAsync(string search)
        {
            var accounts = await _accountRepository.FindAccountsByUserNameAsync(search);

            foreach (var account in accounts.ToList())
            {
                var userAccount = account;

                userAccount = await _accountRepository.GetAccountAsync(account.Id);

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
            await _accountRepository.GetAsync(account.Id);

            await _accountRepository.RemoveAccountAsync(account);
        }

        public async Task<User> GetUserDatailsAsync(User user)
        {
            user.Account = await _accountRepository.GetAccountAsync(user.Id);
            user.Account.AccountStatus = await _accountStatusRepository.GetStatusByFollowersCountAsync(user.Account.Following.Count);

            return user;
        }

        public async Task<IEnumerable<Account>> GetAllAsync(int pageNumber, int pageSize)
        {
            var accounts = await _accountRepository.GetAllAsync(pageNumber, pageSize);

            return accounts;
        }

        public async Task ChangeEmailAsync(User user, string newEmail)
        {
            var changeEmailToken = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);

            var identityResult = await _userManager.ChangeEmailAsync(user, newEmail, changeEmailToken);
            if (identityResult.Errors.Count() > 0)
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<Account>> SearchAsync(string search, int pageNumber, int pageSize)
        {
            var accounts = await _accountRepository.SearchAsync(search, pageNumber, pageSize);

            return accounts;
        }
    }
}
