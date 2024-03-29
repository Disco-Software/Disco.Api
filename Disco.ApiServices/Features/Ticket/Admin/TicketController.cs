﻿using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.GetAllTickets;
using Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.GetTicketsCount;
using Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.SearchTickets;
using Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.UpdateStatus;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.SearchTickets;
using Disco.Business.Interfaces.Dtos.Ticket.Admin.UpdateTicketStatus;
using Disco.Business.Interfaces.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.Admin
{
    [Route("api/admin/tickets")]
    public class TicketController : AdminController
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GetAllTicketsResponseDto>> GetAllAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string statusType) =>
         await _mediator.Send(new GetAllTicketsRequest(pageNumber, pageSize, statusType));

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTicketsCount([FromQuery] bool isArchived) =>
            await _mediator.Send(new GetTicketsCountRequest(isArchived));

        [HttpGet("search")]
        public async Task<IEnumerable<SearchTicketsResponseDto>> SearchAsync(
            [FromQuery] string search,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize) =>
            await _mediator.Send(new SearchTicketsRequest(search, pageNumber, pageSize));

        [HttpPut("change/status")]
        public async Task<ActionResult<UpdateTicketStatusResponseDto>> ChangeStatusAsync(
            [FromQuery] string status,
            [FromQuery] int id) => 
            await _mediator.Send(new UpdateStatusRequest(status, id));
    }
}
