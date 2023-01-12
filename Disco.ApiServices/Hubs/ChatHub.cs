using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.ApiServices.Hubs
{
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
    public class ChatHub : Hub
    {
        private readonly IGroupService _groupService;
        private readonly IMessageService _messageService;
        private readonly IConnectionService _connectionService;
        private readonly IAccountService _accountService;

        public ChatHub(
            IGroupService groupService, 
            IMessageService messageService,
            IConnectionService connectionService,
            IAccountService accountService)
        {
            _groupService = groupService;
            _messageService = messageService;
            _connectionService = connectionService;
            _accountService = accountService;
        }

        public override async Task OnConnectedAsync()
        {
            var user = await _accountService.GetAsync(Context.User);

            var connnection = new Connection()
            {
                IsConnected = true,
                UserAgent = Context.GetHttpContext().Request.Headers["User-Agent"],
                Id = Context.ConnectionId
            };

            await _connectionService.CreateAsync(connnection, user.Account);

            await base.OnConnectedAsync();
        }
        public async Task SendAsync(int groupId, string textMessage)
        {
            var user = await _accountService.GetAsync(Context.User);
            var group = await _groupService.GetAsync(groupId);

            var message = await _messageService.CreateAsync(textMessage, user.Account, group);

            await Clients.Group(group.Name).SendAsync("sendAsync", arg1: message);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = await _accountService.GetAsync(Context.User);
            var connection = await _connectionService.GetAsync(Context.ConnectionId);

            await _connectionService.DeleteAsync(connection, user.Account); ;

            await base.OnDisconnectedAsync(exception);
        }

    }
}
