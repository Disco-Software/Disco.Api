using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext ctx;

        public UserRepository(ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await ctx.Users
                .Include(p => p.Profile)
                .ThenInclude(p => p.Posts)
                .Include(p => p.Profile)
                .ThenInclude(s => s.Stories)
                .Include(p => p.Profile)
                .ThenInclude(f => f.Followers)
                .FirstOrDefaultAsync();
        }

        public async Task GetUserInfosAsync(User user)
        {
            await ctx.Entry(user)
                .Reference(u => u.Profile)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                .Collection(p => p.Posts)
                .LoadAsync();
        }

        public string GetUserRole(User user)
        {
            return ctx.UserRoles
                .Join(ctx.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                .Where(r => r.UserRole.UserId == user.Id)
                .FirstOrDefaultAsync().Result.Role.Name;
        }

        public async Task SaveRefreshTokenAsync(User user, string refreshToken)
        {
            user.RefreshToken = refreshToken;
            
            user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

            await ctx.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers(int pageNumber, int pageSize)
        {
            return await ctx.Users
                .OrderByDescending(d => d.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
