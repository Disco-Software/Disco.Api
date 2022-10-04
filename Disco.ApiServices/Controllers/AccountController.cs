using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Presentation.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
