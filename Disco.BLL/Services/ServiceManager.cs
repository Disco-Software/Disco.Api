using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace Disco.BLL.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthentificationService> authentificationService;
        private readonly Lazy<IPostService> postService;
        private readonly Lazy<IFacebookAuthService> facebookAuthService;

        public ServiceManager(ApiDbContext _ctx, UserManager<User> _userManager, SignInManager<User> _signInManager, FacebookAuthService _facebookAuthService) =>
            authentificationService = new Lazy<IAuthentificationService>(() => new AuthentificationService(_ctx, _userManager, _signInManager, _facebookAuthService));

        public ServiceManager(FacebookOptions options, IHttpClientFactory httpClientFactory) =>
            facebookAuthService = new Lazy<IFacebookAuthService>(() => new FacebookAuthService(options, httpClientFactory));

        public ServiceManager(UserManager<User> _userManager, ApiDbContext _ctx, ClaimsPrincipal _claimsPrincipal) =>
            postService = new Lazy<IPostService>(() => new PostService(_ctx, _claimsPrincipal, _userManager));

        public IAuthentificationService AuthentificationService => authentificationService.Value;

        public IFacebookAuthService FacebookAuthService => facebookAuthService.Value;

        public IPostService PostService => postService.Value;
    }
}
