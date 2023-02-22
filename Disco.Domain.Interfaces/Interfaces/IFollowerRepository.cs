﻿using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IFollowerRepository
    {
        Task AddAsync(UserFollower userFollower);
        Task Remove(UserFollower userFollower);
        Task<UserFollower> GetAsync(int id);
        IQueryable<UserFollower> GetAll();
    }
}
