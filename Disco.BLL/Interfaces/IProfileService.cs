using Disco.BLL.Models.Profile;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IProfileService
    {
        Task<IActionResult> UpdateProfileAsync(UpdateProfileModel model);
    }
}
