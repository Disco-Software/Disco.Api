using Disco.Business.Dtos.Messages;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IMessageService
    {
        Task<MessageResponseDto> CreateMessageAsync(User user, MessageResponseDto modelel);
        Task DeleteMessage(int id);
        Task<MessageResponseDto> GetMessageAsync(int id);
        Task<List<MessageResponseDto>> GetAllMessages(GetAllMessagesDto dto);
    }
}
