﻿using Disco.Business.Interfaces.Dtos.Statistics;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IStatisticsService
    {
        Task<List<User>> GetRegistredUsersAsync(DateTime date);

        Task<List<User>> GetRegistredUsersDayAsync(int days);
    }
}