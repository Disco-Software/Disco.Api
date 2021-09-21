using AutoMapper;
using Disco.BLL.Configurations;
using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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

        public ServiceManager(ApiDbContext _ctx,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IMapper _mapper,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory)
        {
            facebookAuthService = new Lazy<IFacebookAuthService>(() => new FacebookAuthService(configuration, httpClientFactory));
            authentificationService = new Lazy<IAuthentificationService>(() => new AuthentificationService(_ctx, _userManager, _signInManager, facebookAuthService.Value));
            // TODO: Where are from ClaimsPrincipal???
            postService = new Lazy<IPostService>(() => new PostService(_ctx, _mapper, _userManager));
        }
        public IAuthentificationService AuthentificationService => authentificationService.Value;

        public IFacebookAuthService FacebookAuthService => facebookAuthService.Value;

        public IPostService PostService => postService.Value;
    }
}
