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

            var userFollowerResponseDto = _mapper.Map<FollowerResponseDto>(userFollower);
            userFollowerResponseDto.IsFollowing = userFollower.IsFollowing;
            userFollowerResponseDto.FollowingAccount = userFollower.FollowingAccount;
            userFollowerResponseDto.FollowerAccount = userFollower.FollowerAccount;
            
            return userFollowerResponseDto;
        }

        public async Task DeleteAsync(int id)
        {
            var userFollower = await _followerRepository.GetAsync(id);

            userFollower.FollowerAccount.Following.Remove(userFollower);
            userFollower.FollowingAccount.Followers.Remove(userFollower);

            await _followerRepository.Remove(userFollower);
        }

        public async Task<List<FollowerResponseDto>> GetAllAsync(GetAllFollowersDto dto)
        {
            var followers = await _followerRepository.GetAllAsync(dto.UserId, dto.PageNumber, dto.PageSize);

            var followersDto = _mapper.Map<List<FollowerResponseDto>>(followers);

            return followersDto;
        }

        public async Task<List<UserFollower>> GetFollowingAsync(int userId)
        {
            var followings = await _followerRepository.GetFollowingAsync(userId);

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

        public async Task<List<UserFollower>> GetFollowersAsync(int userId)
        {
            var followers = await _followerRepository.GetFollowersAsync(userId);

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
    }
}
