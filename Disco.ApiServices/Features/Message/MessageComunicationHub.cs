using Disco.ApiServices.Features.Comment.RequestHandlers.OnDisconnect;
using Disco.ApiServices.Features.Message.RequestHandlers.CreateMessage;
using Disco.ApiServices.Features.Message.RequestHandlers.DeleteMessage;
using Disco.ApiServices.Features.Message.RequestHandlers.OnConnect;
using Disco.ApiServices.Features.Message.RequestHandlers.OnDisconnect;
using Disco.ApiServices.Features.Message.RequestHandlers.UpdateMessage;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Message.User.CreateMessage;
using Disco.Business.Interfaces.Dtos.Message.User.UpdateMessage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using OnDisconnectRequest = Disco.ApiServices.Features.Message.RequestHandlers.OnDisconnect.OnDisconnectRequest;

namespace Disco.ApiServices.Features.Message
{
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
    public class MessageComunicationHub : Hub
    {
        private readonly IMediator _mediator;

        public MessageComunicationHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task OnConnectedAsync() =>
            await _mediator.Send(new OnConnectRequest(Context.ConnectionId));

        [HubMethodName("create")]
        public async Task CreateAsync(CreateMessageRequestDto dto)
        {
            var message = await _mediator.Send(new CreateMessageRequest(dto));

            await Clients.Group(Context.GetHttpContext().Request.Query["GroupName"]).SendAsync("create",
                arg1: message);
        }

        [HubMethodName("delete")]
        public async Task UpdateAsync(int id)
        {
            await _mediator.Send(new DeleteMessageRequest(id));

            await Clients.Group(Context.GetHttpContext().Request.Query["GroupName"])
                .SendAsync("delete", arg1: id);
        }

        [HubMethodName("update")]
        public async Task DeleteAsync(UpdateMessageRequestDto dto)
        {
            var updateMessageResposneDto = await _mediator.Send(new UpdateMessageRequest(dto));

            await Clients.Group(Context.GetHttpContext().Request.Query["GroupName"])
                .SendAsync("update", arg1: updateMessageResposneDto);
        }

        public override async Task OnDisconnectedAsync(Exception exception) =>
            await _mediator.Send(new OnDisconnectRequest(Context.ConnectionId));

    }
}
