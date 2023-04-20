
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

        public async Task<Account> GetAsync(int id)
        {
            var account = await _context.Users
                .Include(u => u.Account)
                .Select(a => a.Account)
                .Where(a => a.Id == id)
                .SingleAsync();
            
            return account;
        }

        public async Task<Account> GetAccountAsync(int accountId)
        {
            var account = await _context.Users
                .Include(u => u.Account)
                .Select(a => a.Account)
                .Where(a => a.Id == accountId)
                .SingleAsync();

            await _context.Entry(account)
                .Reference(a => a.User)
                .LoadAsync();

            await _context.Entry(account)
                .Collection(account => account.Following)
                .LoadAsync();

            return account;
        }

        public override async Task<Account> Update(Account newItem)
        {
            var account = _context.Accounts.Update(newItem).Entity;
            
            await _context.SaveChangesAsync();
            
            return account;
        }

        public async Task RemoveAccountAsync(int accountId)
        {
            var account = _context.Accounts
                .Include(u => u.User)
                .Where(a => a.Id == accountId)
                .FirstOrDefaultAsync();

            _context.Remove(account);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Connection>> GetAllAccountConnectionsAsync(int accountId)
        {
            var account = await _context.Accounts
                .Include(account => account.Connections)
                .Where(a => a.Id == accountId)
                .SingleAsync();

            return account.Connections;
        }

        public async Task<List<Account>> FindAccountsByUserNameAsync(string search)
        {
           return await _context.Users
                .Include(u => u.Account)
                .Where(u => u.UserName.StartsWith(search))
                .Select(u => u.Account)
                .ToListAsync();
        }
    }
}
