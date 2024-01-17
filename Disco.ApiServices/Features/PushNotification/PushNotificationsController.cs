using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.PushNotification.RequestHandlers.CreateInstallation;
using Disco.ApiServices.Features.PushNotification.RequestHandlers.RemoveInstallation;
using Disco.ApiServices.Features.PushNotification.RequestHandlers.SubmitNotification;
using Disco.Business.Interfaces.Dtos.PushNotifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
