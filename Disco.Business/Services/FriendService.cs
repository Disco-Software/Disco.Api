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
    public class FriendService : IFriendService
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

        public async Task<FriendResponseDto> CreateFriendAsync(User user, User friend, CreateFriendDto model)
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
                FriendProfile = friend.Account,
                UserProfile = user.Account
            };
        }

        public async Task DeleteFriend(int id) =>
            await _friendRepository.Remove(id);

        public async Task<List<FriendResponseDto>> GetAllFriends(GetAllFriendsDto dto)
        {
            var friends = await _friendRepository.GetAllFriends(dto.UserId, dto.PageNumber, dto.PageSize);
            var friendModels = new List<FriendResponseDto>();

            foreach (var friend in friends)
            {
                var friendModel = new FriendResponseDto
                {
                    FriendProfile = friend.AccountFollower,
                    UserProfile = friend.UserAccount,
                    IsConfirmed = friend.IsConfirmed,
                    FriendId = friend.Id,
                };

                friendModels.Add(friendModel);
            }

            return friendModels;
        }

        public async Task<FriendResponseDto> GetFriendAsync(int id)
        {
            var friend = await _friendRepository.Get(id);

            if (friend == null)
                throw new Exception("freind not found");

            var userProfileModel = _mapper.Map<ProfileDto>(friend.UserAccount);

            return new FriendResponseDto
            {
                FriendId = friend.AccountFollower.Id,
                UserProfile = friend.UserAccount,
                IsConfirmed = true,
                FriendProfile = friend.AccountFollower
            };
        }
    }
}
