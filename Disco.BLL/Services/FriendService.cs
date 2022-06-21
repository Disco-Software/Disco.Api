using AutoMapper;
using Disco.BLL.Constants;
using Disco.BLL.DTO;
using Disco.BLL.Handlers;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Friends;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class FriendService : ApiRequestHandlerBase, IFriendService
    {
        private readonly ApiDbContext ctx;
        private readonly FriendRepository repository;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IPushNotificationService pushNotificationService;
        private readonly INotificationHubClient notificationHubClient;
        private readonly IHttpContextAccessor httpContextAccessor;
        public FriendService(
            ApiDbContext _ctx,
            FriendRepository _repository, 
            UserManager<User> _userManager,
            IMapper _mapper,
            IPushNotificationService _pushNotificationService,
            INotificationHubClient _notificationHubClient,
            IHttpContextAccessor _httpContextAccessor)
        {
            ctx = _ctx;
            repository = _repository;
            userManager = _userManager;
            mapper = _mapper;
            pushNotificationService = _pushNotificationService;
            notificationHubClient = _notificationHubClient;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<IActionResult> CreateFriendAsync(CreateFriendModel model)
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

                //await pushNotificationService.SendNewFriendNotificationAsync(new Models.PushNotifications.NewFriendNotificationModel
                //{
                //    FriendId = user.Id,
                //    Title = "You have a new follower",
                //    Body = "Please confirm your new friend",
                //    NotificationType = NotificationTypes.NewFollower,
                //    Tags = $"user-{friend.Id}",
                //});
            }

            return Ok(new FriendResponseModel { FriendId = friend.Id, IsConfirmed = true, FriendProfile = friend.Profile, UserProfile = user.Profile});
        }

        public async Task DeleteFriend(int id) =>
            await repository.Remove(id);

        public async Task<IActionResult> GetAllFriends(int id)
        {
           var friends = await repository.GetAllFriends(id);
            var friendModels = new List<FriendResponseModel>();
            foreach (var friend in friends)
            {
                var friendModel = new FriendResponseModel
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

            var userProfileModel = mapper.Map<ProfileModel>(friend.UserProfile);

            return Ok(new FriendResponseModel { FriendId = friend.ProfileFriend.Id, UserProfile = friend.UserProfile, IsConfirmed = true, FriendProfile = friend.ProfileFriend});
        }
    }
}
