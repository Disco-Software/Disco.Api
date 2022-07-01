using Disco.BLL.Constants;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [Route("api/user/profile")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class UserProfileController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public UserProfileController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] UpdateProfileModel model) =>
            await serviceManager.ProfileService.UpdateProfileAsync(model);
    }
}
