using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories.Base
{
    public class BaseRepository<T, TKey> : IRepository<T, TKey>
        where T : Models.Base.BaseModel<TKey>
    {
        protected readonly ApiDbContext _context;

        public BaseRepository(ApiDbContext context) =>
            _context = context;

        public virtual async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> GetAsync(TKey id)
        {
            return await _context.Set<T>()
                .Where(i => i.Id.Equals(id))
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }

        public virtual IQueryable<T> GetAll(int pageNumber, int pageSize)
        {
            return _context.Set<T>()
                .OrderBy(i => i.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsQueryable();
        }

        public virtual async Task Remove(T item)
        {
            _context.Remove(item);

            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(T newItem)
        {
            _context.Set<T>().Update(newItem);
            
            await _context.SaveChangesAsync();
        }
    }
}
