using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Guards;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConnectionRepository _connectionRepository;

        public ConnectionService(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;

            DefaultGuard.ArgumentNull(_connectionRepository);
        }

        public async Task CreateAsync(Connection connection, Account account)
        {
            account.Connections.Add(connection);

            if (connection == null)
                throw new NullReferenceException();

            await _connectionRepository.CreateAsync(connection);
        }

        public async Task DeleteAsync(Connection connection, Account account)
        {
            account.Connections.Remove(connection);

            await _connectionRepository.DeleteAsync(connection);
        }

        public async Task<Connection> GetAsync(string connectionId)
        {
            return await _connectionRepository.GetAsync(connectionId);
        }
    }
}
