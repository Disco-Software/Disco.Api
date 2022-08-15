using Microsoft.AspNetCore.Mvc;

namespace Disco.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
