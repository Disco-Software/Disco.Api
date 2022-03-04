using AutoMapper;
using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
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
    public class FriendService : IFriendService
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

        public async Task<FriendDTO> CreateFriend(CreateFriendModel model)
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

            await repository.Add(friendResponse);

            return new FriendDTO { FriendProfile = friendResponse.ProfileFriend, UserProfile = friendResponse.UserProfile = userProfile, IsConfirmed = false };
        }

        public async Task DeleteFriend(int id) =>
            await repository.Remove(id);

        public async Task<List<Friend>> GetAllFriends(int id) =>
            await repository.GetAll(f => f.UserProfileId == id);

        public async Task<FriendDTO> GetFriend(int id)
        {
            var friend = await repository.Get(id);
            
            if (friend == null)
                throw new Exception("freind not found");
            
            return new FriendDTO { UserProfile = friend.UserProfile, FriendProfile = friend.ProfileFriend, IsConfirmed = false };
        }
    }
}
