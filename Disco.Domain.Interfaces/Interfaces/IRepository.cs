using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IRepository<T,TKey>
    {
        Task AddAsync(T item);
        Task Remove(T item);
        Task<T> GetAsync(TKey id);
        IQueryable<T> GetAll(int pageNumber, int pageSize);
        Task Update(T newItem);
    }
}
