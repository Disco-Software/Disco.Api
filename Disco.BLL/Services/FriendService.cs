using AutoMapper;
using Disco.BLL.DTO;
using Disco.BLL.Handlers;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Friends;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
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
        private readonly FriendRepository repository;
        private readonly UserManager<User> userManager;
        private readonly ProfileRepository profileRepository;
        private readonly IMapper mapper;
        public FriendService(
            FriendRepository _repository, 
            ProfileRepository _profileRepository,
            UserManager<User> _userManager,
            IMapper _mapper)
        {
            repository = _repository;
            userManager = _userManager;
            profileRepository = _profileRepository;
            mapper = _mapper;
        }

        public async Task<FriendResponseModel> CreateFriendAsync(CreateFriendModel model)
        {
            var userProfile = await profileRepository.Get(model.UserId);
            var friendProfile = await profileRepository.Get(model.FriendId);

            if (userProfile == null && friendProfile == null)
                throw new Exception("user profile or friend profile is null, chacked this please");
           
            if (model.IsFriend == true)
                throw new Exception("friend allready cofirmed");

            var friendResponse = mapper.Map<Friend>(model);
            friendResponse.ProfileFriend = friendProfile;
            friendResponse.UserProfile = userProfile;
            friendResponse.FriendProfileId = model.FriendId;
            friendResponse.UserProfileId = model.UserId;

            var id = await repository.Add(friendResponse);


            var userProfileModel =  ConvertToProfileModel(userProfile);
            var friendProfileModel = ConvertToProfileModel(friendProfile);

            return Ok(friendProfileModel, userProfileModel, id, false, false);
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

           await repository.ConfirmFriendAsync(friend);

            var friendProfileModel = ConvertToProfileModel(friend.ProfileFriend);
            var userProfileModel = ConvertToProfileModel(friend.UserProfile);

            return Ok(friendProfileModel,userProfileModel,friend.Id, isFriend: friend.IsFriend, isConfirmed: friend.IsConfirmed);
        }
    }
}
