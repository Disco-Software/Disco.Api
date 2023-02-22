using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync(int pageNumber, int pageSize);
        Role GetAsync(User user);

    }
}
