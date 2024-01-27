using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class TicketAccountService : ITicketAccountService
    {
        private readonly ITicketAccountRepository _ticketAccountRepository;

        public TicketAccountService(
            ITicketAccountRepository ticketAccountRepository)
        {
            _ticketAccountRepository = ticketAccountRepository;
        }

        public async Task<IEnumerable<UserTicketInfo>> GetAllWithRoleAsync(string roleName)
        {
            var userTicketInfo = await _ticketAccountRepository.GetAllWithRoleAsync(roleName);

            return userTicketInfo;
        }

    }
}
