﻿using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IFollowerRepository
    {
        Task AddAsync(UserFollower userFollower);
        Task<UserFollower> GetAsync(int id);
        Task Remove(UserFollower userFollower);
        Task<IEnumerable<UserFollower>> GetAllAsync(int id, int pageNumber, int pageSize);
        Task<List<UserFollower>> GetFollowingAsync(int userId);
        Task<List<UserFollower>> GetFollowersAsync(int userId);
    }
}