using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Friends;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
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

        public async Task<UserFollower> CreateAsync(User user, User following, CreateFollowerDto dto)
        {
            var userFollower = _mapper.Map<UserFollower>(user);
            userFollower.FollowerAccount = user.Account;
            userFollower.FollowingAccount = following.Account;
            userFollower.FollowingAccountId = following.AccountId;
            userFollower.FollowerAccountId = user.Account.Id;

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
            
            return userFollower;
        }

        public async Task DeleteAsync(int id)
        {
            await _followerRepository.Remove(id);
        }

        public async Task<List<UserFollower>> GetAllAsync(GetAllFollowersDto dto)
        {
            var followers = await _followerRepository.GetAllAsync(dto.UserId, dto.PageNumber, dto.PageSize);

            return followers;
        }

        public async Task<UserFollower> GetAsync(int id)
        {
            var follower = await _followerRepository.GetAsync(id);

            if (follower == null)
                throw new Exception("freind not found");

            return follower;
        }
    }
}
