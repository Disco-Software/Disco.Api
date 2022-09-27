using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task<Profile> GetAsync(int id);
        Task<Profile> Update(Profile newItem);
        Task<List<Profile>> FindProfleByUserNameAsync(string search);
    }
}
