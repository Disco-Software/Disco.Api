using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Ticket.User.RequestHandlers.CreateTicket;
using Disco.Business.Interfaces.Dtos.Ticket.User.CreateTicket;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.User
{
    [Route("api/user/tickets")]
    public class TicketController : UserController
    {
        private readonly IMediator _mentor;

        public TicketController(IMediator mentor)
        {
            _mentor = mentor;
        }

        [HttpPost("create")]
        public async Task CreateAsync([FromBody] CreateTicketRequestDto dto) =>
            await _mentor.Send(new CreateTicketRequest(dto));
    }
}
