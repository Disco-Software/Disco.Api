using Disco.BLL.Interfaces;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Disco.Server.Controllers.User
{
    [ApiController]
    [Authorize]
    [Route("api/user/subscribe")]
    public class UserSubscribeController : Controller
    {
        private readonly ISubscriberService subscriberService;
        public UserSubscribeController(ISubscriberService _subscriberService) =>
            subscriberService = _subscriberService;

        [HttpPost("create-subscribe")]
        public async Task<IActionResult> CreateUserSubscribe([FromBody] UserSubscriber userSubscriber)
        {
           var userSubscribe = await subscriberService.CreateSubscribe(userSubscriber);
            return Ok(userSubscribe);
        }
        
        [HttpDelete("{subscriberId:int}/remove")]
        public async Task<IActionResult> DeleteUserSubscribe([FromRoute] int subscriberId)
        {
            await subscriberService.DeleteSubscribe(subscriberId);
            return Ok("Subscriber was removed");
        }
    }
}
