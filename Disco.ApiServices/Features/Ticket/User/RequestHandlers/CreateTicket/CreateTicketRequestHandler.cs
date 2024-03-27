using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Ticket.User.CreateTicket;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
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
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly ITicketAccountService _ticketAccountService;
        private readonly ITicketService _ticketService;
        private readonly ITicketStatusService _ticketStatusService;
        private readonly ITicketPriorityService _ticketPriorityService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CreateTicketRequestHandler(
            IAccountService accountService,
            IAccountDetailsService accountDetailsService,
            ITicketAccountService ticketAccountService,
            ITicketService ticketService,
            ITicketStatusService ticketStatusService,
            ITicketPriorityService ticketPriorityService,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _accountService = accountService;
            _accountDetailsService = accountDetailsService;
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

            ticket.Title = request.Dto.Title;
            ticket.Description = request.Dto.Description;
            ticket.Status = await _ticketStatusService.GetAsync(request.Dto.Status);
            ticket.Priority = await _ticketPriorityService.GetAsync(request.Dto.Priority);
            
            ticket.CreationDate = DateTime.UtcNow;
            ticket.Owner = user.Account;
            ticket.OwnerId = user.Id;

            var admins = await _accountDetailsService.GetAllWithRoleAsync(UserRole.ADMIN_ROLE);

            var ticketUsers = _mapper.Map<IEnumerable<TicketUser>>(admins);

            foreach (var ticketUser in ticketUsers)
            {
                var ticketAccount = new UserTicketInfo { Id = ticketUser.Id, Ticket = new TicketDetails 
                {
                    Description = ticket.Description, 
                    Id = ticket.Id, 
                    Priority = ticket.Priority.Name, 
                    Status = ticket.Status.Name 
                }, 
                    User = ticketUser
                };

                ticket.Administrators.Add(ticketAccount);
            }

            await _ticketService.CreateAsync(ticket);
        }
    }
}
