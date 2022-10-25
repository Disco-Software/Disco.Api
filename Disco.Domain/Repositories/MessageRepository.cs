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
    public class MessageRepository : BaseRepository<Message, int>, IMessageRepository
    {
        public MessageRepository(ApiDbContext ctx) : base(ctx)
        {
        }

        public async Task<int> AddAsync(Message currentUserMessage)
        {
            await ctx.Messages.AddAsync(currentUserMessage);

            await ctx.SaveChangesAsync();

            return currentUserMessage.Id;
        }
        public override async Task<Message> Get(int id) =>
            await ctx.Messages
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
        public override async Task Remove(int id)
        {
            var message = await ctx.Messages
                  .Where(f => f.Id == id)
                  .FirstOrDefaultAsync();
            ctx.Messages.Remove(message);

            await ctx.SaveChangesAsync();
        }
        public async Task<List<Message>> GetAllMessages(int id, int pageNumber, int pageSize)
        {
            return await ctx.Messages
                .Where(f => f.UserProfileId == id)
                .OrderBy(n => n.CreateDate)
                .Take((pageNumber - 1) * pageSize)
                .Skip(pageSize)
                .ToListAsync();
        }
    }
}
