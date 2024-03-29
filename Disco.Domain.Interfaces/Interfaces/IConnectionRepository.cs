﻿using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IConnectionRepository
    {
        Task CreateAsync(Connection connection);
        Task DeleteAsync(Connection connection);
        Task<Connection> GetAsync(string id);
        Task<Connection> UpdateAsync(Connection connection);
    }
}
