using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.TicketMessage.RequestHandlers.Count;
using Disco.ApiServices.Features.TicketMessage.RequestHandlers.GetAllMessages;
using Disco.Business.Interfaces.Dtos.TicketMessage.GetAllMessages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage
{
    [Route("api/admin/tickets/messages")]
    public class TicketMessageController : UserController
    {
        private readonly IMediator _mediator;

        public TicketMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GetAllMessagesResponseDto>> GetAllAsync(
            [FromQuery] int groupId,
            [FromQuery] int userId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize) =>
            await _mediator.Send(new GetAllMessagesRequest(groupId, pageNumber, pageSize));

        [HttpGet("count")]
        public async Task<int> CountAsync([FromQuery] int ticketId) => 
            await _mediator.Send(new CountRequest(ticketId));
    }
}
