using Disco.DAL.EF;
using Disco.DAL.Entities.BaseEntity;
using Disco.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories.BaseRepository
{
    public class BaseRepository<T, Tkey> : IRepository<T, Tkey> 
        where T : BaseEntity<T>
    {
        protected ApplicationDbContext ctx;
        public BaseRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public virtual async Task Create(T item)
        {
            await ctx.Set<T>().AddAsync(item);
        }

        public virtual async Task Delete(Tkey id)
        {
            var item = await ctx.Set<T>().FirstOrDefaultAsync(b => b.Id.Equals(id));
            ctx.Remove(item);
        }

        public virtual async Task<T> Get(Tkey id)
        {
            return await ctx.Set<T>().FirstOrDefaultAsync(b => b.Id.Equals(id));
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await ctx.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
