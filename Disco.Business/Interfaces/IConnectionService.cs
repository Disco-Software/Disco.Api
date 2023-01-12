using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IConnectionService
    {
        Task CreateAsync(Connection connection, Account account);
        Task DeleteAsync(Connection connection, Account account);
        Task<Connection> GetAsync(string connectionId);
    }
}
