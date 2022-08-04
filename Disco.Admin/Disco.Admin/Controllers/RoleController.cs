using Disco.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Disco.Admin.Controllers
{
    [Route("admin/roles")]
    public class RoleController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RoleController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GetRoles()
        {
            var token = HttpContext.Session.GetString("accessToken");

            var client = httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await client.GetAsync("https://devdiscoapi.azurewebsites.net/api/admin/roles");

            var result = await response.Content.ReadAsStringAsync();

            var roles = JsonConvert.DeserializeObject<List<Role>>(result);

            return View(roles);
        }
    }
}
