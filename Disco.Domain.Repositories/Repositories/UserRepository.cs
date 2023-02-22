using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
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
        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<User> GetAsync(string refreshToken)
        {
            return await _context.Users
                .Include(p => p.Account)
                .ThenInclude(p => p.Posts)
                .Include(p => p.Account)
                .ThenInclude(s => s.Stories)
                .Include(p => p.Account)
                .ThenInclude(f => f.Followers)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException("User not found");
        }

        public IQueryable<User> GetAll(int pageNumber, int pageSize)
        {
            return _context.Users
                .OrderBy(p => p.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsQueryable();
        }

        public IQueryable<User> GetAll(DateTime date)
        {
            return _context.Users
                .Include(u => u.Account)
                .Where(u => u.DateOfRegister == date)
                .OrderBy(u => u.DateOfRegister)
                .AsQueryable();
        }
    }
}
