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

        public override async Task AddAsync(AccountGroup item)
        {
            await base.AddAsync(item);
        }

        public async Task<List<AccountGroup>> GetAllAsync(int id)
        {
            return await _context.AccountGroups
                .Include(accountGroup => accountGroup.Account)
                .Include(accountGroup => accountGroup.Group)
                .Where(accountGroup => accountGroup.AccountId == id)
                .ToListAsync();
        }

        public override async Task<AccountGroup> GetAsync(int id)
        {
            return await base.GetAsync(id);
        }

        public override async Task Remove(AccountGroup item)
        {
           await base.Remove(item);
        }

        public override async Task Update(AccountGroup newItem)
        {
            await base.Update(newItem);
        }
    }
}
