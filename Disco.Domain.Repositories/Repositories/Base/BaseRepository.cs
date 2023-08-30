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

        public BaseRepository(ApiDbContext ctx) =>
            this._context = ctx;

        public virtual async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> GetAsync(TKey id)
        {
            var item = await _context.Set<T>()
                .Where(i => i.Id.Equals(id))
                .FirstOrDefaultAsync();
            return item;
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T,bool>> expression)
        {
            if (expression != null)
                return await _context.Set<T>().Where(expression).ToListAsync();
            else
                return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task RemoveAsync(TKey id)
        {
            var item = await _context.Set<T>().Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();
            
            _context.Remove(item);

            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> Update(T newItem)
        {
            var item = await _context.Set<T>().Where(t => t.Id.Equals(newItem.Id)).FirstOrDefaultAsync();
            _context.Set<T>().Update(newItem);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
