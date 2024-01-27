using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Ticket.User.CreateTicket;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.User.RequestHandlers.CreateTicket
{
    public class CreateTicketRequestHandler : IRequestHandler<CreateTicketRequest>
    {
        private readonly IAccountService _accountService;
        private readonly ITicketAccountService _ticketAccountService;
        private readonly ITicketService _ticketService;
        private readonly ITicketStatusService _ticketStatusService;
        private readonly ITicketPriorityService _ticketPriorityService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CreateTicketRequestHandler(
            IAccountService accountService,
            ITicketAccountService ticketAccountService,
            ITicketService ticketService,
            ITicketStatusService ticketStatusService,
            ITicketPriorityService ticketPriorityService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _ticketAccountService = ticketAccountService;
            _ticketService = ticketService;
            _ticketStatusService = ticketStatusService;
            _ticketPriorityService = ticketPriorityService;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task Handle(CreateTicketRequest request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetAsync(_contextAccessor.HttpContext.User);

            var ticket = _mapper.Map<Domain.Models.Models.Ticket>(request.Dto);
            
            ticket.Status = await _ticketStatusService.GetAsync(request.Dto.Status);
            ticket.Priority = await _ticketPriorityService.GetAsync(request.Dto.Priority);
            
            ticket.CreationDate = DateTime.UtcNow;
            ticket.Owner = user.Account;
            ticket.OwnerId = user.Id;

            ticket.Administrators = _ticketAccountService.GetAllWithRoleAsync(UserRole.ADMIN_ROLE).Result.ToList();

            await _ticketService.CreateAsync(ticket);
        }
    }
}
