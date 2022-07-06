using Microsoft.AspNetCore.Mvc;

namespace Disco.Admin.Controllers
{
    [Route("authentication")]
    public class AuthenticationController : Controller
    {
        [Route("log-in")]
        public async Task<IActionResult> LogIn()
        {
            return View();
        }
    }
}
