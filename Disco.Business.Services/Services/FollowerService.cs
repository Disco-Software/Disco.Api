using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Friends;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Business.Interfaces.Dtos.Followers;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class FollowerService : IFollowerService
    {
        private readonly IMapper _mapper;
        private readonly IFollowerRepository _followerRepository;

        public FollowerService(
            IMapper mapper,
            IFollowerRepository friendRepository)
        {
            _followerRepository = friendRepository;
            _mapper = mapper;
        }

        public async Task<FollowerResponseDto> CreateAsync(User user, User following, CreateFollowerDto dto)
        {
            var userFollower = _mapper.Map<UserFollower>(user);
            userFollower.FollowingAccount = following.Account;
            userFollower.FollowingAccountId = following.AccountId;

            if (user.Account.Following.All(f => f.FollowerAccountId != dto.FollowerAccountId))
            {
                user.Account.Following.Add(userFollower);
            }

            if (following.Account.Followers.All(f => f.FollowingAccountId != user.Account.Id))
            {
                following.Account.Followers.Add(userFollower);
            }

            userFollower.IsFollowing = true;

            await _followerRepository.AddAsync(userFollower);

            var userFollowerResponseDto = _mapper.Map<FollowerResponseDto>(userFollower);
            
            return userFollowerResponseDto;
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

        public async Task<FollowerResponseDto> GetAsync(int id)
        {
            var follower = await _followerRepository.GetAsync(id);

            if (follower == null)
                throw new Exception("freind not found");

            var followerDto = _mapper.Map<FollowerResponseDto>(follower);
            followerDto.FollowerAccount = follower.FollowerAccount;
            followerDto.FollowingAccount = follower.FollowingAccount;
            followerDto.IsFollowing = follower.IsFollowing;

            return followerDto;
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
                if (sortedFollowings.Where(f => f.FollowingAccountId == following.FollowingAccountId).Count() > 1)
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
    }
}
