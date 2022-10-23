using Disco.Business.Dtos.Statistics;
using Disco.Business.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
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
