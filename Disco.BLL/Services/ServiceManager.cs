using AutoMapper;
using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
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
        private readonly Lazy<IPostService> postService;
        private readonly Lazy<IFacebookAuthService> facebookAuthService;
        private readonly Lazy<IRegisterDeviceService> registerDeviceService;
        private readonly Lazy<IEmailService> emailService;
        private readonly Lazy<IRepositoryManager> repositoryManager;
        private readonly Lazy<IFriendService> friendService;
        private readonly Lazy<IPushNotificationService> pushNotificationService;
        private readonly Lazy<IGoogleAuthService> googleAuthService;
        private readonly Lazy<IStoryService> storyService;
        public ServiceManager(ApiDbContext _ctx,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
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
            emailService = new Lazy<IEmailService>(() => new EmailService(_emailOptions,_logger));
            authentificationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_ctx, _userManager, _signInManager, httpContextAccessor,googleAuthService.Value ,facebookAuthService.Value, emailService.Value,authenticationOptions,_googleOptions,_mapper));
            postService = new Lazy<IPostService>(() => new PostService(_mapper,repositoryManager.Value.PostRepository, _ctx, _userManager,httpContextAccessor,hostingEnvironment));
            storyService = new Lazy<IStoryService>(() => new StoryService(repositoryManager.Value.StoryRepository, repositoryManager.Value.ProfileRepository,_ctx, _mapper, hostingEnvironment));
            var notificationHub = NotificationHubClient.CreateClientFromConnectionString(
                configuration["ConnectionStrings:AzureNotificationHubConnection"],
                configuration["NotificationHub:HubName"]);
            registerDeviceService = new Lazy<IRegisterDeviceService>(() => new RegisterDeviceService(notificationHub));
            pushNotificationService = new Lazy<IPushNotificationService>(() => new PushNotificationService(notificationHub));
            friendService = new Lazy<IFriendService>(() => new FriendService(_ctx, repositoryManager.Value.FriendRepository, _userManager, _mapper, pushNotificationService.Value,notificationHub, httpContextAccessor));
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
    }
}
