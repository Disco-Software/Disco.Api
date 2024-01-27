using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Account>> GetAllWithRoleAsync(string roleName)
        {
            return await _context.Accounts
                .Include(x => x.User)
                .Where(x => x.User.RoleName == roleName)
                .ToListAsync();
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

        public async Task<Account> UpdateAsync(Account newItem)
        {
            var account = _context.Accounts.Update(newItem).Entity;
            
            await _context.SaveChangesAsync();
            
            return account;
        }

        public async Task RemoveAccountAsync(Account account)
        {
            _context.Accounts.Remove(account);

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

        public async Task<IEnumerable<Account>> GetAllAsync(int pageNumber, int pageSize)
        {
            var accounts = await _context.Accounts
                .OrderByDescending(a => a.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            foreach (var account in accounts)
            {
                await _context.Entry(account)
                    .Reference(userAccount => userAccount.User)
                    .LoadAsync();

                await _context.Entry(account)
                    .Collection(userAccount => userAccount.Followers)
                    .LoadAsync();
                
                await _context.Entry(account)
                    .Collection(userAccount => userAccount.Following)
                    .LoadAsync();
            }

            return accounts;
        }

        public async Task<IEnumerable<Account>> SearchAsync(string search, int pageNumber, int pageSize)
        {
            var accounts = await _context.Accounts
                .Include(x => x.User)
                .Where(x => x.User.UserName!.Contains(search))
                .OrderBy(x => x.User.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return accounts;
        }

        public int GetAccountsCount()
        {
            return _context.Accounts.Count();
        }

        public int GetAccountsSearchResultCount(string search)
        {
            return _context.Accounts
                .Include(x => x.User)
                .Count(x => x.User.UserName.StartsWith(search));
        }
    }
}
