using Disco.Business.Dtos.Profile;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IProfileService
    {
        Task<User> UpdateProfileAsync(User user, UpdateProfileDto model);
    }
}
