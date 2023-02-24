using Disco.Business.Interfaces.Dtos.Statistics;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IUserRepository _userRepository;

        public StatisticsService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetRegistredUsersAsync(DateTime date)
        {
           return await _userRepository.GetUsersByPeriotAsync(date);
        }

        public async Task<List<User>> GetRegistredUsersDayAsync(int days)
        {
            return await _userRepository.GetUsersByPeriotIntAsync(days);
        }

    }
}
