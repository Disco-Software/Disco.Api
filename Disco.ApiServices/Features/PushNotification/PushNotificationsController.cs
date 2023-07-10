using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.PushNotifications;
using Disco.Business.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.PushNotification
{
    [Route("api/admin/notification")]
    public class PushNotificationsController : ControllerBase
    {
        private readonly IPushNotificationService _pushNotificationService;

        public PushNotificationsController(IPushNotificationService pushNotificationService)
        {
            _pushNotificationService = pushNotificationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInstallationAsync([FromBody] DeviceInstallationDto dto)
        {
            var response = await _pushNotificationService.CreateOrUpdateInstallationAsync(dto, HttpContext.RequestAborted);

            if (!response)
            {
                return BadRequest($"Submit status: {response}");
            }

            return Ok($"Submit status: {response}");
        }

        [HttpDelete("installations/{installationId}")]
        public async Task<IActionResult> RemoveInstallationAsync([FromQuery] string installationId)
        {
            var response = await _pushNotificationService.DeleteInstallationByIdAsync(installationId);

            if (!response)
            {
                return BadRequest($"Installation remove status: {response}");
            }

            return Ok($"Installation remove status: {response}");
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitNotificationAsync([FromBody] PushNotificationBaseDto dto)
        {
            var response = await _pushNotificationService.RequestNotificationAsync(dto, HttpContext.RequestAborted);

            if (!response)
            {
                return BadRequest($"Submit status: {response}");
            }

            return Ok($"Submit status: {response}");
        }
    }
}
