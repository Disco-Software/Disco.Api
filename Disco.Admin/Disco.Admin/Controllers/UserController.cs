using Disco.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Disco.Admin.Controllers
{
    [Route("admin/users")]
    public class UserController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            string? token =  HttpContext.Session.GetString("accessToken");

            if (token == null)
                return Redirect("/authentication/log-in");


            var client = httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await client.GetAsync($"https://devdiscoapi.azurewebsites.net/api/admin/users");

            if (response.StatusCode != HttpStatusCode.OK)
                return Redirect("/authentication/log-in");

            var result = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<List<User>>(result);

            return View(users);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveToken(string token)
        {
            HttpContext.Session.SetString("accessToken", token);

            return NoContent();
        }
    }
}
