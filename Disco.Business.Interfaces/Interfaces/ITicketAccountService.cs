using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface ITicketAccountService
    {
        Task<IEnumerable<UserTicketInfo>> GetAllWithRoleAsync(string roleName);
    }
}
