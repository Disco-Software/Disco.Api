using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IRepository<T,TKey>
    {
        Task AddAsync(T item);
        Task RemoveAsync(T item);
        Task<T> GetAsync(TKey id);
        Task<List<T>> GetAll(Expression<Func<T,bool>> expression);
        Task UpdateAsync(T newItem);
    }
}
