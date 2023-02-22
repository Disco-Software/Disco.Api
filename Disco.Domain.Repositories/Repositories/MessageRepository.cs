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

        public async Task AddAsync(Message message, CancellationToken cancellationToken = default)
        {
            await base.AddAsync(message);
        }

        public async Task Remove(Message message, CancellationToken cancellationToken = default)
        {
            await base.Remove(message);
        }

        public override IQueryable<Message> GetAll(int pageNumber, int pageSize)
        {
            return _context.Messages
                .OrderBy(message => message.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsQueryable();
        }

        public async Task<Message> GetAsync(int id)
        {
            return await _context.Messages
                .Include(m => m.Group)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync()
                ?? throw new NullReferenceException("Message not found");
        }

        public async Task UpdateAsync(Message message, CancellationToken cancellationToken = default)
        {
            _context.Messages.Update(message);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
