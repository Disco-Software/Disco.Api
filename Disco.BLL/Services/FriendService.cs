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
using Microsoft.Azure.NotificationHubs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class FriendService : FriendApiRequestHandlerBase,IFriendService
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

        public async Task<FriendResponseModel> CreateFriendAsync(CreateFriendModel model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            await ctx.Entry(user)
                .Reference(p => p.Profile)
                .LoadAsync();
            
            await ctx.Entry(user.Profile)
                .Collection(f => f.Friends)
                .LoadAsync();


            var friend = await userManager.FindByIdAsync(model.FriendId.ToString());
            await ctx.Entry(friend)
                .Reference(f => f.Profile)
                .LoadAsync();

            await ctx.Entry(friend.Profile)
                .Collection(f => f.Friends)
                .LoadAsync();

            if (user.Profile == null && friend == null)
                throw new Exception("user profile or friend profile is null, chacked this please");
           
            if (model.IsFriend == true)
                throw new Exception("friend allready cofirmed");

            var currentUserFriend = new Friend { UserProfile = user.Profile, ProfileFriend = friend.Profile, FriendProfileId = friend.Profile.Id, IsConfirmed = model.IsConfirmed, IsFriend = model.IsFriend, UserProfileId = user.Profile.Id };

            if (user.Profile.Friends.All(f => f.FriendProfileId != model.FriendId))
                user.Profile.Friends.Add(currentUserFriend);

            var id = await repository.AddAsync(currentUserFriend);


            if (model.IntalationId != null)
            {
                var instalation = await notificationHubClient.GetInstallationAsync(model.IntalationId);
                
               var tags = user.Profile.Friends
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

            var userProfileModel =  ConvertToProfileModel(user.Profile);
            var friendProfileModel = ConvertToProfileModel(friend.Profile);

            return Ok(friendProfileModel, userProfileModel, currentUserFriend.Id, model.IsFriend, model.IsConfirmed);
        }

        public async Task DeleteFriend(int id) =>
            await repository.Remove(id);

        public async Task<List<FriendResponseModel>> GetAllFriends(int id)
        {
           var friends = await repository.GetAllFriends(id);
            var friendModels = new List<FriendResponseModel>();
            foreach (var friend in friends)
            {
                var friendModel = new FriendResponseModel
                {
                    FriendProfile = ConvertToProfileModel(friend.ProfileFriend),
                    UserProfile = ConvertToProfileModel(friend.UserProfile),
                    IsConfirmed = friend.IsConfirmed,
                    FriendId = friend.Id,
                };
                friendModels.Add(friendModel);
            }
            return friendModels;
        }

        public async Task<FriendResponseModel> GetFriendAsync(int id)
        {
            var friend = await repository.Get(id);
            
            if (friend == null)
                throw new Exception("freind not found");

            var userProfile =  ConvertToProfileModel(friend.UserProfile);
            var friendPorfile = ConvertToProfileModel(friend.ProfileFriend);


            return new FriendResponseModel { UserProfile =userProfile , FriendProfile = friendPorfile, IsConfirmed = false };
        }

        private ProfileModel ConvertToProfileModel(DAL.Entities.Profile profile)
        {
            var profileModel = new ProfileModel
            {
                Friends = profile.Friends.Count,
                Posts = profile.Posts.Count,
                Id = profile.Id,
                UserId = profile.UserId,
                Status = profile.Status,
                UserModel = new UserModel
                {
                    Email = profile.User.Email,
                    UserName = profile.User.UserName,
                    Id = profile.UserId
                }
            };
            return profileModel;
        }

        public async Task<FriendResponseModel> IsConfirmFriendAsync(ConfirmationFriendModel model)
        {
            var friend = await repository.Get(model.FriendId);

            if (friend.FriendProfileId != model.FriendProfileId)
                throw new Exception("You can not confirm, becose you send this invetation");

            if (model.IsConfirmed == false)
                throw new Exception("User not confirm your invitation");

            friend.IsConfirmed = model.IsConfirmed;

           await userManager.UpdateAsync(friend.ProfileFriend.User);

            if(model.InstalationId != null)
            {
                var instalation = await notificationHubClient.GetInstallationAsync(model.InstalationId);

                instalation.Tags.Add($"confirmation-{friend.Id}");

                await notificationHubClient.CreateOrUpdateInstallationAsync(instalation);

                await pushNotificationService.SendFriendConfirmationNotificationAsync(new Models.PushNotifications.PushNotificationBaseModel
                {
                    Title = $"{friend.ProfileFriend.User.UserName} confirm your invetation",
                    Body = "Check heas account",
                    NotificationType = NotificationTypes.ConfirmationFollower,
                    Tag = $"confirmation-{friend.Id}",
                }) ;
            }

            var friendProfileModel = ConvertToProfileModel(friend.ProfileFriend);
            var userProfileModel = ConvertToProfileModel(friend.UserProfile);

            return Ok(friendProfileModel,userProfileModel,friend.Id, isFriend: friend.IsFriend, isConfirmed: friend.IsConfirmed);
        }
    }
}
