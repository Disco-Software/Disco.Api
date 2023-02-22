using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string refreshToken);
        IQueryable<User> GetAll(int pageNumber, int pageSize);
        IQueryable<User> GetAll(DateTime date);
    }
}
