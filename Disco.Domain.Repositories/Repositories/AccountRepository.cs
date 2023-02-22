
using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class AccountRepository : BaseRepository<Account, int>, IAccountRepository
    {
        public AccountRepository(ApiDbContext ctx) : base(ctx) { }

        public override Task AddAsync(Account item)
        {
            return base.AddAsync(item);
        }

        public override Task Remove(Account item)
        {
            return base.Remove(item);
        }

        public IQueryable<Account> GetAll()
        {
            return _context.Accounts
                .AsQueryable();
        }

        public override async Task Update(Account newItem)
        {
           await base.Update(newItem);
        }
    }
}
