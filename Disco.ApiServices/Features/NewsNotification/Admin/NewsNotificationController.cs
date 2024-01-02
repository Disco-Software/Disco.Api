using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.NewsNotification.Admin.RequestHandlers.SendNewsNotification;
using Disco.Business.Interfaces.Dtos.NewsNotification.Admin.SendNewsNotification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.NewsNotification.Admin
{
    [Route("api/admin/news")]
    public class NewsNotificationController : AdminController
    {
        private readonly IMediator _mediator;

        public NewsNotificationController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send")]
        public async Task SendAsync([FromBody] SendNewsNotificationRequestDto dto) =>
            await _mediator.Send(new SendNewsNotificationRequest(dto));
    }
}
