﻿using Disco.Domain.EF;
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
            await _ctx.Groups.AddAsync(group);

            await _ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Group group, CancellationToken cancellationToken = default)
        {
            _ctx.Remove(group);

            await _ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Group>> GetAllAsync(int id, int pageNumber, int pageSize)
        {
            return await _ctx.Groups
                .Include(group => group.AccountGroups)
                .Where(g => g.Id == id)
                .OrderByDescending(g => g.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task UpdateAsync(Group group, CancellationToken cancellationToken = default)
        {
            _ctx.Groups.Update(group);

            await _ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task<Group> GetAsync(int id)
        {
            return await _ctx.Groups
                .Include(g => g.AccountGroups)
                .Include(g => g.Messages)
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task LoadAccountsAsync(List<AccountGroup> accountGroup)
        {
           await _ctx.Entry(accountGroup)
                .Collection(c => c)
                .LoadAsync();
        }
    }
}