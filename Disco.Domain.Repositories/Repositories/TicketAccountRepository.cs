using Disco.Domain.EF;
using Disco.Domain.Interfaces.Interfaces;
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
    public class TicketAccountRepository : BaseRepository<TicketAccount, int>, ITicketAccountRepository
    {
        public TicketAccountRepository(ApiDbContext context) : base(context) { }

        public async Task<IEnumerable<UserTicketInfo>> GetAllWithRoleAsync(string roleName)
        {
            return await _context.TicketAccounts
                .Include(x => x.Account)
                .ThenInclude(x => x.User)
                .Select(x => new UserTicketInfo
                {
                    User = new TicketUser
                    {
                        Id = x.Id,
                        UserName = x.Account.User.UserName,
                        RoleName = x.Account.User.RoleName,
                        Photo = x.Account.Photo
                    },
                    Ticket = new TicketDetails
                    {
                        Id = x.Id,
                        Description = x.Ticket.Description,
                        Priority = x.Ticket.Priority.Name,
                        Status = x.Ticket.Status.Name,
                    }
                })
                .ToListAsync();
        }
    }
}
