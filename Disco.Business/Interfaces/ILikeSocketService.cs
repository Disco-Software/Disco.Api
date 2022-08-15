using Disco.Domain.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface ILikeSocketService
    {
        WebSocket GetSocketById(string id);
        ConcurrentDictionary<string, WebSocket> GetAll();
        string GetId(WebSocket socket);
        string AddSocket(WebSocket socket);
        Task RemoveSocket(string id);
        Task SendAsync(WebSocket webSocket, WebSocketReceiveResult webSocketReceiveResult, byte[] buffer, int postId);
    }
}
