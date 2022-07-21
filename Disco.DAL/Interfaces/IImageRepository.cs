using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task AddAsync(PostImage item);
        Task Remove(int id);
    }
}
