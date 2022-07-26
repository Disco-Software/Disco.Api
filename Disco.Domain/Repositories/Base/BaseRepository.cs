using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Base
{
    public class BaseRepository<T, Tkey> : IRepository<T, Tkey>
        where T : Models.Base.BaseEntity<Tkey>
        where Tkey : struct
    {
        protected readonly ApiDbContext _ctx;

        public BaseRepository(ApiDbContext ctx) =>
            _ctx = ctx;

        public virtual async Task AddAsync(T item)
        {
            await _ctx.Set<T>().AddAsync(item);
            await _ctx.SaveChangesAsync();
        }

        public virtual async Task<T> Get(Tkey id)
        {
            var item = await _ctx.Set<T>()
                .Where(i => i.Id.Equals(id))
                .FirstOrDefaultAsync();
            return item;
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T,bool>> expression)
        {
            if (expression != null)
                return await _ctx.Set<T>().Where(expression).ToListAsync();
            else
                return await _ctx.Set<T>().ToListAsync();
        }

        public virtual async Task Remove(Tkey id)
        {
            var item = await _ctx.Set<T>().Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();
            _ctx.Remove(item);
        }

        public virtual async Task<T> Update(T newItem)
        {
            var item = await _ctx.Set<T>().Where(t => t.Id.Equals(newItem.Id)).FirstOrDefaultAsync();
            _ctx.Set<T>().Update(newItem);
            await _ctx.SaveChangesAsync();
            return item;
        }
    }
}
