using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class SubscriberService //: ISubscriberService
    {
        private readonly ApplicationDbContext ctx;
        private readonly ApplicationUserManager userManager;
        private readonly ClaimsPrincipal claimsPrincipal;

        public SubscriberService(ApplicationDbContext _ctx, ApplicationUserManager _manager, ClaimsPrincipal _claimsPrincipal)
        {
            this.ctx = _ctx;
            this.userManager = _manager;
            this.claimsPrincipal = _claimsPrincipal;
        }

        public async Task<UserSubscriber> CreateSubscribe(UserSubscriber subscriber)
        {
            var user = await ctx.Users.Where(u => u.Id == subscriber.UserId).FirstOrDefaultAsync();
            var userSubscriber = await ctx.Users.Where(s => s.Id == subscriber.SubscriberId).FirstOrDefaultAsync();
            if (user.UserSubscribers.All(u => u.SubscriberId != userSubscriber.Id))
            {
                user.UserSubscribers.Add(subscriber);
            }
            await userManager.UpdateAsync(user);
            return user.UserSubscribers.FirstOrDefault(s => s.Id == subscriber.Id);
        }

        public async Task DeleteSubscribe(int subscriberId)
        {
            var user = await userManager.GetUserAsync(claimsPrincipal);
            var subscriber = user.UserSubscribers.Where(s => s.Id == subscriberId).FirstOrDefault();
            ctx.UserSubscribers.Remove(subscriber);
        }

        public async Task<List<UserSubscriber>> GetAllSubscribes(Expression<Func<UserSubscriber, bool>> subscribers)
        {
            if (subscribers != null)
                return await ctx.UserSubscribers.Where(subscribers).ToListAsync();
            else
                return await ctx.UserSubscribers.ToListAsync();
        }
    }
}
