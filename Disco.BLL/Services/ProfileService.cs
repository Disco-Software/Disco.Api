using Azure.Storage.Blobs;
using Disco.BLL.Handlers;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Profile;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class ProfileService : ApiRequestHandlerBase, IProfileService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly BlobServiceClient blobServiceClient;
        private readonly ProfileRepository profileRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ProfileService(
            ApiDbContext _ctx,
            UserManager<User> _userManager,
            BlobServiceClient _blobServiceClient,
            ProfileRepository _profileRepository,
            IHttpContextAccessor _httpContextAccessor)
        {
            ctx = _ctx;
            userManager = _userManager;
            blobServiceClient = _blobServiceClient;
            profileRepository = _profileRepository;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<IActionResult> UpdateProfileAsync(UpdateProfileModel model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            await ctx.Entry(user)
                .Reference(p => p.Profile)
                .LoadAsync();

            if(user.Profile.Photo != null)
            {
                var unequeName = Guid.NewGuid().ToString() + "_" + model.Photo.Name.Replace(" ", "_");

                var blobContainerClient = blobServiceClient.GetBlobContainerClient("images");
                var blobClient = blobContainerClient.GetBlobClient(unequeName);

                using var stream = model.Photo.OpenReadStream();
                blobClient.Upload(stream);

                user.Profile.Photo = blobClient.Uri.AbsoluteUri ?? user.Profile.Photo;
            }

            user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;
            user.Profile.Cread = model.Cread ?? user.Profile.Cread;

            await profileRepository.Update(user.Profile);

            return Ok(user);
        }
    }
}
