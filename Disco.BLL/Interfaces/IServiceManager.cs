using Disco.Domain.Interfaces;
using Disco.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Interfaces
{
    public interface IServiceManager
    {
        IAuthenticationService AuthentificationService { get; }
        IFacebookAuthService FacebookAuthService { get; }
        IGoogleAuthService GoogleAuthService { get; }
        IAdminRoleService RoleService { get; }
        IPostService PostService { get; }
        IRegisterDeviceService RegisterDeviceService { get; }
        IEmailService EmailService { get; }
        IFriendService FriendService { get; }
        IStoryService StoryService { get; }
        IPushNotificationService PushNotificationService { get; }
        ISongService SongService { get; }
        IImageService ImageService { get; }
        IVideoService VideoService { get; }
        ILikeSevice LikeSevice { get; }
        IStoryImageService StoryImageService { get; }
        IStoryVideoService StoryVideoService { get; }
        ITokenService TokenService { get; }
        IProfileService ProfileService { get; }
        IAdminAuthenticationService AdminAuthenticationService { get; }
        IAdminUserService AdminUserService { get; }
        IRepositoryManager RepositoryManager { get; }
    }
}
