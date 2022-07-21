﻿using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
    }
}
