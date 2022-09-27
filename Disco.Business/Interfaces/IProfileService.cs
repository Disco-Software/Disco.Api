using Disco.Business.Dtos.Profile;
using Disco.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IProfileService
    {
        Task<User> UpdateProfileAsync(User user, UpdateProfileDto model);
        Task<IEnumerable<Profile>> GetProfilesByName(string search);
    }
}
