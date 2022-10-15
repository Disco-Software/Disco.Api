using Disco.Business.Dtos.Profile;
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
        Task<IEnumerable<Account>> GetProfilesByName(string search);
    }
}
