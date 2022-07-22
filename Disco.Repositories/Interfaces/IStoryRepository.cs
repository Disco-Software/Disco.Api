﻿using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IStoryRepository
    {
        Task AddAsync(Story story, Profile profile);
        Task<List<Story>> GetAllAsync(int profileId, int pageNumber, int pageSize);
        Task Remove(int id);
        Task<Story> Get(int id);
    }
}