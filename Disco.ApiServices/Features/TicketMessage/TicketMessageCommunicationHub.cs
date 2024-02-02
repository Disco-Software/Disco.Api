using Disco.ApiServices.Features.TicketMessage.RequestHandlers.DeleteMessageForAll;
using Disco.ApiServices.Features.TicketMessage.RequestHandlers.DeleteMesssageForSender;
using Disco.ApiServices.Features.TicketMessage.RequestHandlers.OnConnect;
using Disco.ApiServices.Features.TicketMessage.RequestHandlers.OnDisconnect;
using Disco.ApiServices.Features.TicketMessage.RequestHandlers.SendMessage;
using Disco.ApiServices.Features.TicketMessage.RequestHandlers.UpdateTicketMessage;
using Disco.Business.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.TicketMessage
{
    [Authorize(AuthenticationSchemes = AuthSchema.DEFAULT_USER_AUTHENTICATION)]
    public class TicketMessageCommunicationHub : Hub
    {
        private readonly IMediator _mediator;

        public TicketMessageCommunicationHub(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task OnConnectedAsync() =>
            await _mediator.Send(new OnConnectRequest(
                Context.GetHttpContext().Request.Query["ticketName"],
                Context.GetHttpContext().Request.Query["userName"],
                Context.ConnectionId));

        [HubMethodName("send")]
        public async Task SendMessageAsync(string message, string ticketName, int ticketId)
        {
            var result = await _mediator.Send(new SendMessageRequest(message, ticketId, ticketName));

            await Clients.Group(ticketName).SendAsync("receive", result);
        }

        [HubMethodName("delete-for-me")]
        public async Task DeleteForSenderAsync(int id)
        {
            await _mediator.Send(new DeleteForSenderRequest(id));

            await Clients.Caller.SendAsync("removeForSender");
        }

        [HubMethodName("delete-for-all")]
        public async Task DeleteAsync(int id)
        {
            await _mediator.Send(new DeleteMessageForAllRequest(id));

            await Clients.Group(Context.GetHttpContext().Request.Query["ticketName"]).SendAsync("remove");
        }

        [HubMethodName("update")]
        public async Task UpdateAsync(int id, string message)
        {
            var result = await _mediator.Send(new UpdateTicketMessageRequest(id, message));

            await Clients.Group(Context.GetHttpContext().Request.Query["ticketName"]).SendAsync("update", arg1: result);
        }

        public override async Task OnDisconnectedAsync(Exception exception) =>
            await _mediator.Send(new OnDisconnectRequest(Context.ConnectionId));
    }
}
