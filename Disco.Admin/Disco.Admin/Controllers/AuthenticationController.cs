using Microsoft.AspNetCore.Mvc;

namespace Disco.Admin.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
