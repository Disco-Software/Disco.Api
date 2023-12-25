using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class AccountGroupRepository : BaseRepository<AccountGroup, int>, IAccountGroupRepository
    {
        public AccountGroupRepository(ApiDbContext context) : base(context) { }

        public async Task CreateAsync(AccountGroup accountGroup)
        {
            await _context.AccountGroups.AddAsync(accountGroup);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AccountGroup accountGroup)
        {
            _context.AccountGroups.Remove(accountGroup);

            await _context.SaveChangesAsync();
        }

        public async Task<AccountGroup> GetAsync(int groupId, int accountId)
        {
            return await _context.AccountGroups
                .Include(x => x.Account)
                .Include(x => x.Group)
                .Where(a => a.GroupId == groupId)
                .Where(a => a.AccountId == accountId)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<AccountGroup>> GetAllAsync(int id)
        {
            return await _context.AccountGroups
                .Include(ag => ag.Group)
                .Include(ag => ag.Account)
                .Where(a => a.Id == id)
                .ToListAsync();
        }

    }
}
