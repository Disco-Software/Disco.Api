using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApiDbContext _ctx;

        public RoleRepository(ApiDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Role>> GetAll(int pageNumber, int pageSize)
        {
            return await _ctx.Roles
                 .OrderBy(x => x.Name)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();
        }
    }
}
