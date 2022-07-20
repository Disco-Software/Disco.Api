using Disco.Business.Dto.Profile;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IProfileService
    {
        Task<IActionResult> UpdateProfileAsync(UpdateProfileDto model);
    }
}
