using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Handlers;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Friends;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class FriendService : ApiRequestHandlerBase, IFriendService
    {
        private readonly IMapper _mapper;
        private readonly IFriendRepository _friendRepository;
        private readonly IConfiguration _configuration;
        public FriendService(
            IMapper mapper,
            IFriendRepository friendRepository,
            IConfiguration configuration)
        { 
            this._friendRepository = friendRepository;
            this._mapper = mapper;
            this._configuration = configuration;
        }

        public async Task<FriendResponseDto> CreateFriendAsync(User user, User friend, CreateFriendDto model)
        {           
            var currentUserFriend = new Friend { UserProfile = user.Profile, ProfileFriend = friend.Profile, FriendProfileId = friend.Profile.Id, UserProfileId = user.Profile.Id };

            if (user.Profile.Following.All(f => f.FriendProfileId != model.FriendId))
                user.Profile.Following.Add(currentUserFriend);

            if(friend.Profile.Followers.All(f => f.UserProfileId != user.Profile.Id))
                friend.Profile.Followers.Add(currentUserFriend);

            currentUserFriend.IsConfirmed = true;

            var id = await _friendRepository.AddAsync(currentUserFriend);

            //if (model.IntalationId != null)
            //{
            //    var instalation = await notificationHubClient.GetInstallationAsync(model.IntalationId);
                
            //   var tags = user.Profile.Followers
            //        .Select(u => $"user-{u.ProfileFriend.UserId}")
            //        .ToList();

            //    tags.Add($"user-{friend.Id}");

            //    instalation.Tags = tags;

            //   await notificationHubClient.CreateOrUpdateInstallationAsync(instalation);
            //}

            return new FriendResponseDto { FriendId = friend.Id, IsConfirmed = true, FriendProfile = friend.Profile, UserProfile = user.Profile};
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
                    FriendProfile = friend.ProfileFriend,
                    UserProfile = friend.UserProfile,
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

            var userProfileModel = _mapper.Map<ProfileDto>(friend.UserProfile);

            return new FriendResponseDto { FriendId = friend.ProfileFriend.Id, UserProfile = friend.UserProfile, IsConfirmed = true, FriendProfile = friend.ProfileFriend };
        }
    }
}
