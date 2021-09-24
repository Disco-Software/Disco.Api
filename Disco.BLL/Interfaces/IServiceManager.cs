using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Interfaces
{
    public interface IServiceManager
    {
        IAuthentificationService AuthentificationService { get; }
        IFacebookAuthService FacebookAuthService { get; }
        IPostService PostService { get; }
        IRegisterDeviceService RegisterDeviceService { get; }
    }
}
