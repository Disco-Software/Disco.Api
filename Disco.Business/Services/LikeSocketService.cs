using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class LikeSocketService : ILikeSocketService
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets;
        public LikeSocketService()
        {
            _sockets = new ConcurrentDictionary<string, WebSocket>();
        }

        public string AddSocket(WebSocket socket)
        {
            var id = Guid.NewGuid().ToString();
            _sockets.TryAdd(id, socket);

            return id;
        }

        public ConcurrentDictionary<string, WebSocket> GetAll()
        {
            return _sockets;
        }

        public string GetId(WebSocket socket)
        {
            return _sockets.FirstOrDefault(p => p.Value == socket).Key;
        }

        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        }

        public async Task RemoveSocket(string id)
        {
            WebSocket socket;
            _sockets.TryRemove(id, out socket);

            await socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                                    statusDescription: "Closed by the WebSocketManager",
                                    cancellationToken: CancellationToken.None);
        }

        public async Task SendAsync(WebSocket webSocket, WebSocketReceiveResult result,  byte[] buffer, int postId)
        {
            foreach (var pair in _sockets)
            {
                if (pair.Value.State == WebSocketState.Open)
                    await ReciveAsync(pair.Value, result, postId);
            }
        }

        public async Task SendLikeAsync(WebSocket socket, int postId)
        {
            if (socket.State != WebSocketState.Open)
                return;

            await socket.SendAsync(buffer: new ArraySegment<byte>(array: Encoding.ASCII.GetBytes(postId.ToString()),
                                                                    offset: 0,
                                                                    count: postId.ToString().Length),
                                    messageType: WebSocketMessageType.Text,
                                    endOfMessage: true,
                                    cancellationToken: CancellationToken.None);
        }


        private async Task ReciveAsync(WebSocket socket, WebSocketReceiveResult reciveResult, int likesCount)
        {
            var buffer = new byte[1024 * 4];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                         cancellationToken: CancellationToken.None);

                await SendLikeAsync(socket, likesCount);
            }
        }
    }
}