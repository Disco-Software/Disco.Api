using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Repositories.Repositories
{
    public class AccountStatusRepository : Base.BaseRepository<Status, int>, IAccountStatusRepository
    {
        public AccountStatusRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task<AccountStatus> GetStatusByFollowersCountAsync(int followersCount)
        {
            var status = await _context.Statuses
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

            return status;
        }
    }
}
