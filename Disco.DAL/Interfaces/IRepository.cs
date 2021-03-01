using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Interfaces
{
    public interface IRepository<T,TKey> 
        where T : class
        where TKey : struct
    {
        Task Create(T item);
        Task Delete(TKey id);
        Task<T> Get(TKey id);
        Task<List<T>> GetAll();
    }
}
