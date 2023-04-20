using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _ctx;

        public UserRepository(ApiDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await _ctx.Users
                .Include(p => p.Account)
                .ThenInclude(p => p.Posts)
                .Include(p => p.Account)
                .ThenInclude(s => s.Stories)
                .Include(p => p.Account)
                .ThenInclude(f => f.Followers)
                .FirstOrDefaultAsync();
        }

        public async Task GetUserAccountAsync(User user)
        {
            await _ctx.Entry(user)
                .Reference(u => u.Account)
                .LoadAsync();

            await _ctx.Entry(user.Account)
                .Collection(p => p.Posts)
                .LoadAsync();
        }

        public string GetUserRole(User user)
        {
            return _ctx.UserRoles
                .Join(_ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                .Where(r => r.UserRole.UserId == user.Id)
                .FirstOrDefaultAsync().Result.Role.Name;
        }

        public async Task SaveRefreshTokenAsync(User user, string refreshToken)
        {
            user.RefreshToken = refreshToken;
            
            user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

            await _ctx.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers(int pageNumber, int pageSize)
        {
            return await _ctx.Users
                .OrderByDescending(d => d.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersByPeriotAsync(DateTime date)
        {
            return await _ctx.Users
                .Include(u => u.Account)
                .Where(u => u.DateOfRegister == date)
                .OrderBy(u => u.DateOfRegister)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersByPeriotIntAsync(int days)
        {
            var date = DateTime.Now;
            date = date.AddDays(-days);

            return await _ctx.Users
                .Include(u => u.Account)
                .Where(u => u.DateOfRegister >= date)
                .OrderBy(u => u.DateOfRegister)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _ctx.Users.ToListAsync();
        }
        public async Task<List<User>> GetAllUsersAsync(DateTime from, DateTime to)
        {
            return await _ctx.Users
                .Where(user => user.DateOfRegister <= to || user.DateOfRegister >= from)
                .OrderBy(user => user.DateOfRegister)
                .ToListAsync();
        }
    }
}
