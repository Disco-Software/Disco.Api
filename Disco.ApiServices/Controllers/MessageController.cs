using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Friends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Disco.Business.Dtos.Messages;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;

namespace Disco.ApiServices.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/user/messages")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly NavigationManager _navigationManager;
        private HubConnection? hubConnection;
        public MessageController(
            IMessageService messageService,
            IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [HttpPost("connect")]
        public async Task<IActionResult> Connect()
        {
            var user = await _userService.GetUserAsync(HttpContext.User);
            hubConnection = new HubConnectionBuilder()
            .WithUrl(_navigationManager.ToAbsoluteUri($"/chathub?username={user.UserName}"))
            .Build();
            await hubConnection.StartAsync();
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] MessageResponseDto model)
        {
            if (hubConnection != null)
            {
                var user = await _userService.GetUserAsync(HttpContext.User);
                var messageResponse = await _messageService.CreateMessageAsync(user, model);
                await hubConnection.SendAsync("AddMessageToChat", user.UserName, model.MessageText);
                return Ok(messageResponse);
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpPost("dispose")]
        public async Task<IActionResult> Dispose()
        {
            if (hubConnection != null)
            {
                await hubConnection.DisposeAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpGet("get/{messageId:int}")]
        public async Task<IActionResult> GetMessage([FromRoute] int messageId)
        {
            var message = await _messageService.GetMessageAsync(messageId);

            return Ok(message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMessagesDto dto)
        {
            var friends = await _messageService.GetAllMessages(dto);

            return Ok(friends);
        }

        [HttpDelete("{messageId:int}")]
        public async Task DeleteMessage([FromRoute] int messageId)
        {
            await _messageService.DeleteMessage(messageId);
        }
    }
}
