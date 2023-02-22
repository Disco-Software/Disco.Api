using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApiDbContext _ctx;

        public RoleRepository(ApiDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Role>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _ctx.Roles
                 .OrderBy(x => x.Name)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();
        }

        public Role GetAsync(User user)
        {
            return _ctx.UserRoles
                .Join(_ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                .Where(r => r.UserRole.UserId == user.Id)
                .FirstOrDefaultAsync().Result.Role ?? throw new NullReferenceException("Role not found");
        }
    }
}
