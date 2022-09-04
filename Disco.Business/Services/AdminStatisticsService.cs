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
    public class AdminStatisticsService : IAdminStatisticsService
    {
        private readonly IUserRepository _userRepository;

        public AdminStatisticsService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetRegistredUsersAsync(DateTime date)
        {
           return await _userRepository.GetUsersByPeriotAsync(date);
        }
    }
}
