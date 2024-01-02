using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Email.Admin.RequestHandlers.SendEmailNotification;
using Disco.Business.Interfaces.Dtos.EmailNotifications.Admin.AdminEmailNotification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Email.Admin
{
    [Microsoft.AspNetCore.Mvc.Route("api/admin/emails")]
    public class EmailController : AdminController
    {
        private readonly IMediator _mediator;

        public EmailController(
            IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost("admin/send")]
        public async Task SendAdminNotificationAsync([FromBody] AdminEmailNotificationRequestDto adminEmailNotificationRequestDto) =>
            await _mediator.Send(new SendEmailNotificationRequest(adminEmailNotificationRequestDto));
    }
}
