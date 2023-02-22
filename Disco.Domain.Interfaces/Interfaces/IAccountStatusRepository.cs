using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IAccountStatusRepository
    {
        Task<AccountStatus> GetAsync(int followersCount);
    }
}
