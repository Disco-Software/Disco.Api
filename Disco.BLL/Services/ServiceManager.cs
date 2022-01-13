using AutoMapper;
using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Interfaces;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
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
        public ServiceManager(ApiDbContext _ctx,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IMapper _mapper,
            IOptions<PushNotificationOptions> pushNotificationOptions,
            IOptions<AuthenticationOptions> authenticationOptions,
            IOptions<EmailOptions> _emailOptions,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment,
            IHttpClientFactory httpClientFactory)
        {
            repositoryManager = new Lazy<IRepositoryManager>(() => new RepositoryManager(_ctx));
            facebookAuthService = new Lazy<IFacebookAuthService>(() => new FacebookAuthService(configuration, httpClientFactory));
            emailService = new Lazy<IEmailService>(() => new EmailService(_emailOptions));
            authentificationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_ctx, _userManager, _signInManager, facebookAuthService.Value, emailService.Value,authenticationOptions,_mapper));
            postService = new Lazy<IPostService>(() => new PostService(_mapper,repositoryManager.Value.PostRepository, _ctx, _userManager,hostingEnvironment));
            var notificationHub = NotificationHubClient.CreateClientFromConnectionString(
                configuration["ConnectionStrings:AzureNotificationHubConnection"],
                configuration["NotificationHub:HubName"]);
            registerDeviceService = new Lazy<IRegisterDeviceService>(() => new RegisterDeviceService(notificationHub));
        }
        public IAuthenticationService AuthentificationService => authentificationService.Value;

        public IFacebookAuthService FacebookAuthService => facebookAuthService.Value;

        public IPostService PostService => postService.Value;

        public IRegisterDeviceService RegisterDeviceService => registerDeviceService.Value;

        public IEmailService EmailService => emailService.Value;

       public IRepositoryManager RepositoryManager => throw new NotImplementedException();
    }
}
