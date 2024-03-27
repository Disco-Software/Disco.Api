using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users
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
            await _context.Entry(user)
                .Reference(u => u.Account)
                .LoadAsync();

            await _context.Entry(user.Account)
                .Collection(p => p.Posts)
                .LoadAsync();
        }

        public string GetUserRole(User user)
        {
            return _context.UserRoles
                .Join(_context.Roles, r => r.RoleId, u => u.Id, (u, r) => new { Role = r, UserRole = u })
                .Where(r => r.UserRole.UserId == user.Id)
                .FirstOrDefaultAsync().Result.Role.Name;
        }

        public async Task SaveRefreshTokenAsync(User user, string refreshToken)
        {
            user.RefreshToken = refreshToken;
            
            user.RefreshTokenExpiress = DateTime.UtcNow.AddDays(7);

            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers(int pageNumber, int pageSize)
        {
            return await _context.Users
                .OrderByDescending(d => d.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersByPeriotAsync(DateTime date)
        {
            return await _context.Users
                .Include(u => u.Account)
                .Where(u => u.DateOfRegister == date)
                .OrderBy(u => u.DateOfRegister)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersByPeriotIntAsync(int days)
        {
            var date = DateTime.Now;
            date = date.AddDays(-days);

            return await _context.Users
                .Include(u => u.Account)
                .Where(u => u.DateOfRegister >= date)
                .OrderBy(u => u.DateOfRegister)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<List<User>> GetAllUsersAsync(DateTime from, DateTime to)
        {
            return await _context.Users
                .Where(user => user.DateOfRegister <= to && user.DateOfRegister >= from)
                .OrderBy(user => user.DateOfRegister)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetUsersEmailsAsync(string search)
        {
            return await _context.Users
                .Where (user => user.Email.Contains(search))
                .Select(user => user.Email)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetUsersNamesAsync(string search)
        {
            return await _context.Users
                .Where(x => x.UserName.StartsWith(search))
                .Select(x => x.UserName)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllWithRoleAsync(string roleName)
        {
            return await _context.Users
                .Include(x => x.Account)
                .Where(x => x.RoleName == roleName)
                .ToListAsync();
        }

        public async Task<int> GetUsersCountAsync(DateTime from, DateTime to)
        {
            return await _context.Users
                .CountAsync(x => x.DateOfRegister >= from && x.DateOfRegister <= to);
        }
    }
}
