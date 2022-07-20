using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Models;
using Disco.DAL.Interfaces;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace Disco.BLL.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> authentificationService;
        private readonly Lazy<IAdminAuthenticationService> adminAuthenticationService;
        private readonly Lazy<IPostService> postService;
        private readonly Lazy<IAdminRoleService> roleService;
        private readonly Lazy<IFacebookAuthService> facebookAuthService;
        private readonly Lazy<IRegisterDeviceService> registerDeviceService;
        private readonly Lazy<IEmailService> emailService;
        private readonly Lazy<IRepositoryManager> repositoryManager;
        private readonly Lazy<IFriendService> friendService;
        private readonly Lazy<IPushNotificationService> pushNotificationService;
        private readonly Lazy<IGoogleAuthService> googleAuthService;
        private readonly Lazy<IStoryService> storyService;
        private readonly Lazy<IStoryImageService> storyImageService;
        private readonly Lazy<IStoryVideoService> storyVideoService;
        private readonly Lazy<ISongService> songService;
        private readonly Lazy<IImageService> imageService;
        private readonly Lazy<IVideoService> videoService;
        private readonly Lazy<ILikeSevice> likeSevice;
        private readonly Lazy<ITokenService> tokenService;
        private readonly Lazy<IProfileService> profileService;
        private readonly Lazy<IAdminUserService> adminUserService;
        public ServiceManager(ApiDbContext _ctx,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<Role> _roleManager,
            BlobServiceClient _blobServiceClient,
            IMapper _mapper,
            IOptions<PushNotificationOptions> pushNotificationOptions,
            IOptions<AuthenticationOptions> authenticationOptions,
            IOptions<EmailOptions> _emailOptions,
            IOptions<GoogleOptions> _googleOptions,
            ILogger<ServiceManager> _logger,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            repositoryManager = new Lazy<IRepositoryManager>(() => new RepositoryManager(_ctx));
            facebookAuthService = new Lazy<IFacebookAuthService>(() => new FacebookAuthService(configuration, httpClientFactory));
            googleAuthService = new Lazy<IGoogleAuthService>(() => new GoogleAuthService(httpClientFactory));
            emailService = new Lazy<IEmailService>(() => new EmailService(_emailOptions));
            tokenService = new Lazy<ITokenService>(() => new TokenService(authenticationOptions));
            authentificationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_ctx, _userManager, _signInManager, _blobServiceClient, repositoryManager.Value.UserRepository,httpContextAccessor,tokenService.Value,googleAuthService.Value ,facebookAuthService.Value, emailService.Value,authenticationOptions,_googleOptions,_mapper));
            var notificationHub = NotificationHubClient.CreateClientFromConnectionString(
                configuration["ConnectionStrings:AzureNotificationHubConnection"],
                configuration["NotificationHub:HubName"]);
            registerDeviceService = new Lazy<IRegisterDeviceService>(() => new RegisterDeviceService(configuration));
            pushNotificationService = new Lazy<IPushNotificationService>(() => new PushNotificationService(configuration));
            roleService = new Lazy<IAdminRoleService>(() => new AdminRoleService(_ctx, _roleManager,_mapper));
            friendService = new Lazy<IFriendService>(() => new FriendService(_ctx, repositoryManager.Value.FriendRepository, _userManager, _mapper, configuration, httpContextAccessor));
            imageService = new Lazy<IImageService>(() => new ImageService(repositoryManager.Value.PostRepository, repositoryManager.Value.ImageRepository, _blobServiceClient, _mapper));
            songService = new Lazy<ISongService>(() => new SongService(repositoryManager.Value.SongRepository, repositoryManager.Value.PostRepository, _blobServiceClient, _mapper, httpContextAccessor));
            videoService = new Lazy<IVideoService>(() => new VideoService(repositoryManager.Value.VideoRepository, repositoryManager.Value.PostRepository, _blobServiceClient, _mapper));
            likeSevice = new Lazy<ILikeSevice>(() => new LikeService(_ctx, repositoryManager.Value.PostRepository, repositoryManager.Value.LikeRepository,_userManager, httpContextAccessor));
            postService = new Lazy<IPostService>(() => new PostService(repositoryManager.Value.PostRepository, _ctx, _userManager, _mapper, imageService.Value, songService.Value, videoService.Value, httpContextAccessor));
            storyService = new Lazy<IStoryService>(() => new StoryService(repositoryManager.Value.StoryRepository, _userManager, _ctx, storyImageService.Value,storyVideoService.Value,_mapper,httpContextAccessor));
            storyImageService = new Lazy<IStoryImageService> (() => new StoryImageService(repositoryManager.Value.StoryImageRepository, repositoryManager.Value.StoryRepository, _userManager, _blobServiceClient, _mapper, httpContextAccessor));
            storyVideoService = new Lazy<IStoryVideoService>(() => new StoryVideoService(repositoryManager.Value.StoryVideoRepository, repositoryManager.Value.StoryRepository, _userManager, _blobServiceClient, _mapper, httpContextAccessor));
            profileService = new Lazy<IProfileService>(() => new ProfileService(_ctx,_userManager,_blobServiceClient,repositoryManager.Value.ProfileRepository,httpContextAccessor));
            adminAuthenticationService = new Lazy<IAdminAuthenticationService>(() => new AdminAuthenticationService(_ctx, _userManager, _signInManager, repositoryManager.Value.UserRepository, _blobServiceClient, httpContextAccessor, _mapper, tokenService.Value, authenticationOptions, emailService.Value));
            adminUserService = new Lazy<IAdminUserService>(() => new AdminUserService(_ctx, _userManager, _mapper));
        }
        public IAuthenticationService AuthentificationService => authentificationService.Value;

        public IFacebookAuthService FacebookAuthService => facebookAuthService.Value;

        public IPostService PostService => postService.Value;

        public IRegisterDeviceService RegisterDeviceService => registerDeviceService.Value;

        public IEmailService EmailService => emailService.Value;

        public IRepositoryManager RepositoryManager => repositoryManager.Value;

        public IFriendService FriendService => friendService.Value;

        public IGoogleAuthService GoogleAuthService => googleAuthService.Value;

        public IStoryService StoryService => storyService.Value;

         public IPushNotificationService PushNotificationService => throw new NotImplementedException();

         public ISongService SongService => songService.Value;

        public IImageService ImageService => imageService.Value;

        public IVideoService VideoService => throw new NotImplementedException();

        public ILikeSevice LikeSevice => 
            likeSevice.Value;

       public IStoryImageService StoryImageService => 
            storyImageService.Value;

       public IStoryVideoService StoryVideoService =>
            storyVideoService.Value;

       public ITokenService TokenService => 
            tokenService.Value;

       public IProfileService ProfileService => profileService.Value;

       public IAdminRoleService RoleService => roleService.Value;

       public IAdminAuthenticationService AdminAuthenticationService => adminAuthenticationService.Value;

       public IAdminUserService AdminUserService => adminUserService.Value;
    }
}
