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
using Disco.Domain.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Disco.Business.Services.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IUserRepository _userRepository;

        public StatisticsService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetRegistredUsersAsync(int days, int pageNumber, int pageSize)
        {
            var date = DateTime.UtcNow.AddDays(-days);

            var users = await _userRepository.GetAll(date)
                .OrderBy(x => x.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return users;
        }

        public async Task<List<User>> GetRegistredUsersDayAsync(int days)
        {
            return await _userRepository.GetUsersByPeriotIntAsync(days);
        }

    }
}
