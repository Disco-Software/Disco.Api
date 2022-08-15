using Disco.Business.Interfaces;
using System.Threading.Tasks;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Disco.Domain.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Disco.Business.Constants;
using System.Security.Claims;

namespace Disco.Api.Middlewares
{
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class WebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;
        private readonly ILikeService _likeService;
        private readonly ILikeSocketService _likeSocketService;

        public WebSocketMiddleware(
            RequestDelegate next,
            IUserService userService,
            ILikeService likeService,
            ILikeSocketService likeSocketService)
        {
            _next = next;
            _userService = userService;
            _likeService = likeService;
            _likeSocketService = likeSocketService;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await _next.Invoke(context);
                return;
            }

            var socket = await context.WebSockets.AcceptWebSocketAsync();
            var id = _likeSocketService.AddSocket(socket);

            await Receive(socket, async (result, buffer) =>
            {
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _likeSocketService.RemoveSocket(id);
                    return;
                }
                else if (result.MessageType == WebSocketMessageType.Text)
                {
                    var user = await _userService.GetUserAsync(context.User);

                    using var response = new MemoryStream();
                    var postId = response.Read(buffer, 0, buffer.Length);

                    var likes = await _likeService.CreateLikeAsync(user, postId);

                    await _likeSocketService.SendAsync(socket, result,buffer, likes.Count);
                    return;
                }
            });
        }

        private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 4];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                         cancellationToken: CancellationToken.None);
                handleMessage(result, buffer);
            }
        }
    }
}
