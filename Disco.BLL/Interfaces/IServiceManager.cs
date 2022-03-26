using Disco.DAL.Interfaces;
using Disco.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Interfaces
{
    public interface IServiceManager
    {
        IAuthenticationService AuthentificationService { get; }
        IFacebookAuthService FacebookAuthService { get; }
        IGoogleAuthService GoogleAuthService { get; }
        IPostService PostService { get; }
        IRegisterDeviceService RegisterDeviceService { get; }
        IEmailService EmailService { get; }
        IFriendService FriendService { get; }
        IRepositoryManager RepositoryManager { get; }
    }
}
