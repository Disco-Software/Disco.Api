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
    public class FriendService : IFollowerService
    {
        private readonly IMapper _mapper;
        private readonly IFollowerRepository _friendRepository;

        public FriendService(
            IMapper mapper,
            IFollowerRepository friendRepository)
        {
            _friendRepository = friendRepository;
            _mapper = mapper;
        }

        public async Task<FriendResponseDto> CreateAsync(User user, User friend, CreateFollowerDto model)
        {
            var currentUserFriend = new UserFollower
            {
                UserAccount = user.Account,
                AccountFollower = friend.Account,
                FollowerId = friend.Account.Id,
                UserAccountId = user.Account.Id
            };

            if (user.Account.Following.All(f => f.FollowerId != model.FriendId))
            {
                user.Account.Following.Add(currentUserFriend);
            }

            if (friend.Account.Followers.All(f => f.UserAccountId != user.Account.Id))
            {
                friend.Account.Followers.Add(currentUserFriend);
            }

            currentUserFriend.IsConfirmed = true;

            _ = await _friendRepository.AddAsync(currentUserFriend);
            
            return new FriendResponseDto
            {
                FriendId = friend.Id,
                IsConfirmed = true,
                FollowerAccount = friend.Account,
                UserAccount = user.Account
            };
        }

        public async Task DeleteFriend(int id)
        {
            await _friendRepository.Remove(id);
        }

        public async Task<List<FriendResponseDto>> GetAllFollowers(GetAllFriendsDto dto)
        {
            var friends = await _friendRepository.GetAllFriends(dto.UserId, dto.PageNumber, dto.PageSize);
            var friendModels = new List<FriendResponseDto>();

            foreach (var friend in friends)
            {
                var followerDto = new FriendResponseDto
                {
                    FollowerAccount = friend.AccountFollower,
                    UserAccount = friend.UserAccount,
                    IsConfirmed = friend.IsConfirmed,
                    FriendId = friend.Id,
                };

                friendModels.Add(followerDto);
            }

            return friendModels;
        }

        public async Task<FriendResponseDto> GetAsync(int id)
        {
            var follower = await _friendRepository.GetAsync(id);

            if (follower == null)
                throw new Exception("freind not found");

            var userAccountDto = _mapper.Map<AccountDto>(follower.UserAccount);

            return new FriendResponseDto
            {
                FriendId = follower.AccountFollower.Id,
                UserAccount = follower.UserAccount,
                IsConfirmed = true,
                FollowerAccount = follower.AccountFollower
            };
        }
    }
}
