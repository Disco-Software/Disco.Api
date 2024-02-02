using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class TicketMessageService : ITicketMessageService
    {
        private readonly ITicketMessageRepository _ticketMessageRepository;

        public TicketMessageService(
            ITicketMessageRepository ticketMessageRepository)
        {
            _ticketMessageRepository = ticketMessageRepository;
        }

        public async Task CreateAsync(TicketMessage message)
        {
            message.Ticket.TicketMessages.Add(message);

            await _ticketMessageRepository.AddAsync(message);
        }

        public async Task DeleteAsync(TicketMessage message)
        {
            message.Ticket.TicketMessages.Remove(message);

            await _ticketMessageRepository.RemoveAsync(message);
        }

        public async Task DeleteForSenderAsync(TicketMessage message)
        {
            message.IsDeleted = true;

            await _ticketMessageRepository.UpdateTicketAsync(message);
        }

        public async Task<IEnumerable<TicketMessage>> GetAllAsync(int ticketId, int userId, int pageNumber, int pageSize)
        {
            return await _ticketMessageRepository.GetAllAsync(ticketId, userId, pageNumber, pageSize);
        }

        public async Task<TicketMessage> GetAsync(int id)
        {
            return await _ticketMessageRepository.GetAsync(id);
        }

        public async Task UpdateAsync(TicketMessage message)
        {
            await _ticketMessageRepository.UpdateTicketAsync(message);
        }
    }
}
