using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface ISongRepository
    {
        Task AddAsync(PostSong song);
        Task Remove(int id);
    }
}
