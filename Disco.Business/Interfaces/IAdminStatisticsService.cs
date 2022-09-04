using Disco.Business.Dtos.Statistics;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAdminStatisticsService
    {
        Task<List<User>> GetRegistredUsersAsync(DateTime date);
    }
}
