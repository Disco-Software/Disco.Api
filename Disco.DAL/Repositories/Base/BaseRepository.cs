using Disco.DAL.EF;
using Disco.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories.Base
{
    public class BaseRepository<T, Tkey> : IRepository<T, Tkey>
        where T : Entities.Base.BaseEntity<Tkey>
        where Tkey : struct
    {
        protected ApiDbContext ctx;

        public BaseRepository(ApiDbContext _ctx) =>
            ctx = _ctx;

        public virtual async Task Add(T item)
        {
            await ctx.Set<T>().AddAsync(item);
            await ctx.SaveChangesAsync();
        }

        public virtual async Task<T> Get(Tkey id)
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

        public virtual async Task Remove(Tkey id)
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
