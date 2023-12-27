using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class FollowerService : IFollowerService
    {
        private readonly IMapper _mapper;
        private readonly IFollowerRepository _followerRepository;
        private readonly IAccountRepository _accountRepository;

        public FollowerService(
            IMapper mapper,
            IFollowerRepository friendRepository,
            IAccountRepository accountRepository)
        {
            _followerRepository = friendRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task CreateAsync(UserFollower userFollower)
        {
            if (userFollower.FollowerAccount.Following.All(f => f.FollowerAccountId != userFollower.FollowingAccountId))
            {
                userFollower.FollowerAccount.Following.Add(userFollower);
            }

            if (userFollower.FollowingAccount.Followers.All(f => f.FollowingAccountId != userFollower.FollowerAccountId))
            {
                userFollower.FollowingAccount.Followers.Add(userFollower);
            }

            userFollower.IsFollowing = true;

            await _followerRepository.AddAsync(userFollower);
        }

        public async Task DeleteAsync(int id)
        {
            var userFollower = await _followerRepository.GetAsync(id);

            userFollower.FollowerAccount.Following.Remove(userFollower);
            userFollower.FollowingAccount.Followers.Remove(userFollower);

            await _followerRepository.Remove(userFollower);
        }

        public async Task<List<UserFollower>> GetFollowingAsync(int accountId)
        {
            var followings = await _followerRepository.GetFollowingAsync(accountId);

            foreach (var following in followings.ToList())
            {
                if(followings.Where(f => f.FollowingAccountId == following.FollowingAccountId).ToList().Count > 1)
                {
                    followings.Remove(following);
                    continue;
                }
            }

            return followings;
        }

        public async Task<UserFollower> GetAsync(int id)
        {
            var follower = await _followerRepository.GetAsync(id);

            if (follower == null)
                throw new Exception("freind not found");

            return follower;
        }

        public async Task<List<UserFollower>> GetFollowersAsync(int accountId)
        {
            var followers = await _followerRepository.GetFollowersAsync(accountId);

            foreach (var follower in followers.ToList())
            {
                if(followers.Where(f => f.FollowerAccountId == follower.FollowerAccountId).Count() > 1)
                {
                    followers.Remove(follower);
                    continue;
                }
            }

            return followers;
        }

        public async Task<List<UserFollower>> GetFollowingAsync(int userId, int pageNumber, int pageSize)
        {
            var followings = await _followerRepository.GetFollowingAsync(userId, pageNumber, pageSize);

            var sortedFollowings = followings.OrderBy(following => following.FollowingAccount.User.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            foreach (var following in sortedFollowings.ToList())
            {
                if (sortedFollowings.Where(f => f.FollowingAccountId == following.FollowerAccountId).Count() > 1)
                {
                    followings.Remove(following);
                    continue;
                }
            }


            return sortedFollowings;
        }

        public async Task<List<UserFollower>> GetFollowersAsync(int accountId, int pageNumber, int pageSize)
        {
            var followers = await _followerRepository.GetFollowersAsync(accountId, pageNumber, pageSize);

            var sortedFollowers = followers
                .OrderBy(follower => follower.FollowerAccount.User.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            foreach (var follower in sortedFollowers.ToList())
            {
                if (sortedFollowers.Where(f => f.FollowerAccountId == follower.FollowerAccountId).Count() > 1)
                {
                    followers.Remove(follower);
                    continue;
                }
            }

            return sortedFollowers;
        }

        public int GetFollowersCount(int accountId)
        {
            var followersCount = _followerRepository.GetFollowersCount(accountId);

            return followersCount;
        }

        public int GetFollowingsCount(int accountId)
        {
            var followings = _followerRepository.GetFollowingCount(accountId);

            return followings;
        }
    }
}
