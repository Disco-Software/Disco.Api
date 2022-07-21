using Disco.Business.Dto.Profile;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IProfileService
    {
        Task<IActionResult> UpdateProfileAsync(UpdateProfileDto model);
    }
}
