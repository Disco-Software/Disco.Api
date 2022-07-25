using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAll(int pageNumber, int pageSize);
    }
}
