﻿using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Message> GetAllGroupMessages(int groupId, int pageNumber, int pageSize)
        {
            return _context.Messages
                .Include(x => x.Account)
                .ThenInclude(x => x.User)
                .Include(x => x.Group)
                .OrderByDescending(x => x.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsEnumerable();
        }

        public override async Task<Message> GetAsync(int id)
        {
            return await _context.Messages
                .Include(x => x.Account)
                .ThenInclude(x => x.Messages)
                .Include(x => x.Group)
                .ThenInclude(x => x.Messages)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
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
