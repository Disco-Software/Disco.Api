using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.PushNotification.RequestHandlers.CreateInstallation;
using Disco.ApiServices.Features.PushNotification.RequestHandlers.RemoveInstallation;
using Disco.ApiServices.Features.PushNotification.RequestHandlers.SubmitNotification;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.PushNotifications;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.PushNotification
{
    [Route("api/admin/notification")]
    public class PushNotificationsController : AdminController
    {
        private readonly IMediator _mediator;

        public PushNotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<string>> CreateInstallationAsync([FromBody] DeviceInstallationDto dto) =>
            await _mediator.Send(new CreateInstallationRequest(dto));

        [HttpDelete("installations/{installationId}")]
        public async Task<ActionResult<string>> RemoveInstallationAsync([FromQuery] string installationId) =>
            await _mediator.Send(new RemoveInstallationRequest(installationId));

        [HttpPost("submit")]
        public async Task<ActionResult<string>> SubmitNotificationAsync([FromBody] PushNotificationBaseDto dto) =>
            await _mediator.Send(new SubmitNotificationRequest(dto));
    }
}
