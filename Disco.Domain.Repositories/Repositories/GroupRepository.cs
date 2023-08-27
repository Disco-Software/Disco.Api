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
using System.Threading;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class GroupRepository : BaseRepository<Group, int>, IGroupRepository
    {
        public GroupRepository(ApiDbContext context) : base(context) { }


        public async Task CreateAsync(Group group, CancellationToken cancellationToken = default)
        {
            await _context.Groups.AddAsync(group);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Group group, CancellationToken cancellationToken = default)
        {
            _context.Remove(group);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Group>> GetAllAsync(int id, int pageNumber, int pageSize)
        {
            var groups = await _context.Groups
                .Include(group => group.AccountGroups)
                .ToListAsync();

            foreach (var group in groups)
            {
                if(group.AccountGroups.Where(accountGroups => accountGroups.AccountId == id).FirstOrDefault() != null)
                {
                    foreach (var accountGroup in group.AccountGroups)
                    {
                        await _context.Entry(accountGroup)
                            .Reference(accountGroup => accountGroup.Account)
                            .LoadAsync();
                        
                        await _context.Entry(accountGroup.Account)
                            .Reference(account => account.User)
                            .LoadAsync();
                    }
                }
            }

            return groups;
        }

        public async Task UpdateAsync(Group group, CancellationToken cancellationToken = default)
        {
            _context.Groups.Update(group);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Group> GetAsync(int id)
        {
            return await _context.Groups
                .Include(g => g.AccountGroups)
                .Include(g => g.Messages)
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
