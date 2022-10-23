using Disco.Business.Dtos.Account;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAccountDetailsService
    {
        Task<User> ChengePhotoAsync(User user, IFormFile formFile);
        Task<List<Account>> GetAccountsByNameAsync(string search);
        Task RemoveAsync(Account account);
    }
}
