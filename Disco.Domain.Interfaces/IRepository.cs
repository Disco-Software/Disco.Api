using Disco.Domain.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IRepository<T, Tkey> 
        where T : BaseEntity<Tkey>
        where Tkey : struct
    {
        Task Create(T item);
        Task Delete(Tkey id);
        Task<T> Get(Tkey id);
        Task<List<T>> GetAll();
    }
}
