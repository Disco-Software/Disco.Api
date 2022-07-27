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
    public class BaseRepository<T, TKey> : IRepository<T, TKey>
        where T : Models.Base.BaseEntity<TKey>
        where TKey : struct
    {
        protected readonly ApiDbContext ctx;

        public BaseRepository(ApiDbContext ctx) =>
            this.ctx = ctx;

        public virtual async Task AddAsync(T item)
        {
            await ctx.Set<T>().AddAsync(item);
            await ctx.SaveChangesAsync();
        }

        public virtual async Task<T> Get(TKey id)
        {
            var item = await ctx.Set<T>()
                .Where(i => i.Id.Equals(id))
                .FirstOrDefaultAsync();
            return item;
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T,bool>> expression)
        {
            if (expression != null)
                return await ctx.Set<T>().Where(expression).ToListAsync();
            else
                return await ctx.Set<T>().ToListAsync();
        }

        public virtual async Task Remove(TKey id)
        {
            var item = await ctx.Set<T>().Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();
            ctx.Remove(item);
        }

        public virtual async Task<T> Update(T newItem)
        {
            var item = await ctx.Set<T>().Where(t => t.Id.Equals(newItem.Id)).FirstOrDefaultAsync();
            ctx.Set<T>().Update(newItem);
            await ctx.SaveChangesAsync();
            return item;
        }
    }
}
