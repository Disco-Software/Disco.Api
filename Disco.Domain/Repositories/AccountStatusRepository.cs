using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class AccountStatusRepository : Base.BaseRepository<Status, int>, IAccountStatusRepository
    {
        public AccountStatusRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task<AccountStatus> GetStatusByFollowersCountAsync(int followersCount)
        {
            return await _ctx.Statuses
                .Where(x => followersCount < x.UserTarget)
                .Where(x => followersCount >= x.FollowersCount)
                .Select(x => new AccountStatus
                {
                    FollowersCount = followersCount,
                    LastStatus = x.LastStatus,
                    NextStatusId = x.NextStatusId,
                    UserTarget = x.UserTarget,
                })
                .FirstOrDefaultAsync();
        }
    }
}
