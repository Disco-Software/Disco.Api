using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Profile;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System.Collections.Generic;

namespace Disco.Business.Services
{
    public class ProfileService : IProfileService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IUserService _userService;
        private readonly IProfileRepository _profileRepository;
        public ProfileService(
            BlobServiceClient blobServiceClient,
            IUserService userService,
            IProfileRepository profileRepository)
        {
            _blobServiceClient = blobServiceClient;
            _userService = userService;
            _profileRepository = profileRepository;
        }

        public async Task<User> UpdateProfileAsync(User user, UpdateProfileDto model)
        {
            if(user.Profile.Photo != null)
            {
                var unequeName = Guid.NewGuid().ToString() + "_" + model.Photo.Name.Replace(" ", "_");

                var blobContainerClient = _blobServiceClient.GetBlobContainerClient("images");
                var blobClient = blobContainerClient.GetBlobClient(unequeName);

                using var stream = model.Photo.OpenReadStream();
                blobClient.Upload(stream);

                user.Profile.Photo = blobClient.Uri.AbsoluteUri ?? user.Profile.Photo;
            }

            user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;
            user.Profile.Cread = model.Cread ?? user.Profile.Cread;

            await _profileRepository.Update(user.Profile);

            return user;
        }

        public async Task<IEnumerable<Profile>> GetProfilesByName(string search)
        {
            return await _profileRepository.FindProfleByUserNameAsync(search);
        }
    }
}
