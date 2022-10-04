using Disco.Business.Constants;
using Disco.Business.Dtos.PushNotifications;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Presentation.Controllers.Admin
{
    [Route("api/admin/notification")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken, 
        Roles = UserRole.Admin)]
    public class PushNotificationsController : ControllerBase
    {
        private readonly IPushNotificationService _pushNotificationService;

        public PushNotificationsController(IPushNotificationService pushNotificationService)
        {
            _pushNotificationService = pushNotificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] AdminMessageNotificationDto adminMessageNotificationDto)
        {
            await _pushNotificationService.SendNotificationAsync(adminMessageNotificationDto);
            return Ok("Your notification was submited");
        }
    }
}
