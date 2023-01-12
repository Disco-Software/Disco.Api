
using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class AccountRepository : BaseRepository<Account, int>, IAccountRepository
    {
        public AccountRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task<Account> GetAsync(int id)
        {
           return await _ctx.Accounts
                  .Include(u => u.User)
                  .Where(p => p.Id == id)
                  .FirstOrDefaultAsync();
        }

        public override async Task<Account> Update(Account newItem)
        {
            var profile = _ctx.Accounts.Update(newItem).Entity;
            
            await _ctx.SaveChangesAsync();
            
            return profile;
        }

        public async Task RemoveAccountAsync(int accountId)
        {
            var account = _ctx.Accounts
                .Include(u => u.User)
                .Where(a => a.Id == accountId)
                .FirstOrDefaultAsync();

            _ctx.Remove(account);

            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Connection>> GetAllAccountConnectionsAsync(int accountId)
        {
            return await _ctx.Accounts
                .Where(a => a.Id == accountId)
                .SelectMany(a => a.Connections)
                .ToListAsync();
        }

        public async Task<List<Account>> FindAccountsByUserNameAsync(string search)
        {
            return await _ctx.Accounts
                .Include(u => u.User)
                .Include(s => s.AccountStatus)
                .Where(u => u.User.UserName.StartsWith(search))
                .ToListAsync();
        }
    }
}
