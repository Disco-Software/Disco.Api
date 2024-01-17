using AutoMapper;
using Disco.ApiServices.Features.Comment.RequestHandlers.CreateComment;
using Disco.ApiServices.Features.Comment.RequestHandlers.DeleteComment;
using Disco.ApiServices.Features.Comment.RequestHandlers.OnConnect;
using Disco.ApiServices.Features.Comment.RequestHandlers.OnDisconnect;
using Disco.ApiServices.Features.Comment.RequestHandlers.UpdateComment;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Comment.User.CreateComment;
using Disco.Business.Interfaces.Dtos.Comment.User.DeleteComment;
using Disco.Business.Interfaces.Dtos.Comment.User.UpdateComment;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Comment
{
    [Authorize(AuthenticationSchemes = AuthSchema.DEFAULT_USER_AUTHENTICATION)]
    public class CommentComunicationHub : Hub
    {
        private readonly IMediator _mediator;

        public CommentComunicationHub(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task OnConnectedAsync()
        {
            await _mediator.Send(new OnConnectRequest());
        }

        [HubMethodName("send")]
        public async Task SendCommentAsync(CreateCommentRequestDto commentRequestDto)
        {
            var comment = await _mediator.Send(new CreateCommentRequest(commentRequestDto));

            await Clients.All.SendAsync("recive", comment);
        }

        [HubMethodName("remove")]
        public async Task RemoveCommentAsync(DeleteCommentRequestDto dto)
        {
            await _mediator.Send(new DeleteCommentRequest(dto));

            await Clients.All.SendAsync("remove");
        }

        [HubMethodName("update")]
        public async Task UpdateCommentAsync(UpdateCommentRequestDto dto)
        {
            var response = await _mediator.Send(new UpdateCommentRequest(dto));

            await Clients.All.SendAsync("update", response);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await _mediator.Send(new OnDisconnectRequest());
        }
    }
}
