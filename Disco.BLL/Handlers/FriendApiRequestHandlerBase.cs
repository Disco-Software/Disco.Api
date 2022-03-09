using Disco.BLL.Models.Friends;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Handlers
{
    public abstract class FriendApiRequestHandlerBase
    {
        public static FriendResponseModel Ok(ProfileModel friendProfile, ProfileModel userProfile, bool isFriend = false, bool isConfirmed = false) => new FriendResponseModel { FriendProfile = friendProfile, UserProfile = userProfile, IsConfirmed = isConfirmed };
        public static FriendResponseModel Ok() => new FriendResponseModel();
    }
}
