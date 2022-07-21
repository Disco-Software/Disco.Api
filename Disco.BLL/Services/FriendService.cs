using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Dto;
using Disco.Business.Handlers;
using Disco.Business.Interfaces;
using Disco.Business.Dto;
using Disco.Business.Dto.Friends;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class FriendService : ApiRequestHandlerBase, IFriendService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IFriendRepository repository;
        private readonly IConfiguration configuration;
        private readonly IPushNotificationService pushNotificationService;
        private readonly INotificationHubClient notificationHubClient;
        private readonly IHttpContextAccessor httpContextAccessor;
        public FriendService(
            ApiDbContext _ctx,
            UserManager<User> _userManager,
            IMapper _mapper,
            IFriendRepository _repository,
            IConfiguration _configuration,
            IHttpContextAccessor _httpContextAccessor)
        {
            ctx = _ctx;
            repository = _repository;
            userManager = _userManager;
            mapper = _mapper;
            configuration = _configuration;
            notificationHubClient = NotificationHubClient.CreateClientFromConnectionString(
                configuration[Strings.NOTIFICATION_CONNECTION_STRING],
                configuration[Strings.NOTIFICATION_NAME]);
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<IActionResult> CreateFriendAsync(CreateFriendDto model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            
            await ctx.Entry(user)
                .Reference(p => p.Profile)
                .LoadAsync();
            
            await ctx.Entry(user.Profile)
                .Collection(f => f.Followers)
                .LoadAsync();


            var friend = await userManager.FindByIdAsync(model.FriendId.ToString());
           
            await ctx.Entry(friend)
                .Reference(f => f.Profile)
                .LoadAsync();

            await ctx.Entry(friend.Profile)
                .Collection(f => f.Followers)
                .LoadAsync();

            if (user.Profile == null && friend == null)
                throw new Exception("user profile or friend profile is null, chacked this please");
           
            var currentUserFriend = new Friend { UserProfile = user.Profile, ProfileFriend = friend.Profile, FriendProfileId = friend.Profile.Id, UserProfileId = user.Profile.Id };

            if (user.Profile.Following.All(f => f.FriendProfileId != model.FriendId))
                user.Profile.Following.Add(currentUserFriend);

            if(friend.Profile.Followers.All(f => f.UserProfileId != user.Profile.Id))
                friend.Profile.Followers.Add(currentUserFriend);

            currentUserFriend.IsConfirmed = true;

            var id = await repository.AddAsync(currentUserFriend);


            if (model.IntalationId != null)
            {
                var instalation = await notificationHubClient.GetInstallationAsync(model.IntalationId);
                
               var tags = user.Profile.Followers
                    .Select(u => $"user-{u.ProfileFriend.UserId}")
                    .ToList();

                tags.Add($"user-{friend.Id}");

                instalation.Tags = tags;

               await notificationHubClient.CreateOrUpdateInstallationAsync(instalation);
            }

            return Ok(new FriendResponseDto { FriendId = friend.Id, IsConfirmed = true, FriendProfile = friend.Profile, UserProfile = user.Profile});
        }

        public async Task DeleteFriend(int id) =>
            await repository.Remove(id);

        public async Task<IActionResult> GetAllFriends(int id)
        {
           var friends = await repository.GetAllFriends(id, 1, 10);
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
            return Ok(friendModels);
        }

        public async Task<IActionResult> GetFriendAsync(int id)
        {
            var friend = await repository.Get(id);

            if (friend == null)
                throw new Exception("freind not found");

            var userProfileModel = mapper.Map<ProfileDto>(friend.UserProfile);

            return Ok(new FriendResponseDto { FriendId = friend.ProfileFriend.Id, UserProfile = friend.UserProfile, IsConfirmed = true, FriendProfile = friend.ProfileFriend});
        }
    }
}
