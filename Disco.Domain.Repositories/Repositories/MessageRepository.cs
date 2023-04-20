using Disco.Domain.EF;
using Disco.Domain.Interfaces;
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

namespace Disco.Domain.Repositories.Repositories
{
    public class MessageRepository : BaseRepository<Message, int>, IMessageRepository
    {
        public MessageRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task CreateAsync(Message message, CancellationToken cancellationToken = default)
        {
           await _context.Messages.AddAsync(message, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Message message, CancellationToken cancellationToken = default)
        {
            _context.Messages.Remove(message);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Message>> GetAllAsync(int groupId, int pageNumber, int pageSize)
        {
            return await _context.Messages
                .Where(m => m.GroupId == groupId)
                .OrderBy(m => m.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _context.Messages
                .Include(m => m.Group)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Message message, CancellationToken cancellationToken = default)
        {
            _context.Messages.Update(message);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
