using Azure.Storage.Blobs;
using Disco.Business.Handlers;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Profile;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class ProfileService : ApiRequestHandlerBase, IProfileService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly BlobServiceClient blobServiceClient;
        private readonly IProfileRepository profileRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ProfileService(
            ApiDbContext _ctx,
            UserManager<User> _userManager,
            BlobServiceClient _blobServiceClient,
            IProfileRepository _profileRepository,
            IHttpContextAccessor _httpContextAccessor)
        {
            ctx = _ctx;
            userManager = _userManager;
            blobServiceClient = _blobServiceClient;
            profileRepository = _profileRepository;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<IActionResult> UpdateProfileAsync(UpdateProfileDto model)
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
