using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.BLL.Models.Friends;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IFriendService
    {
        Task<FriendResponseModel> CreateFriendAsync(CreateFriendModel model);
        Task DeleteFriend(int id);
        Task<FriendResponseModel> GetFriendAsync(int id);
        Task<List<Friend>> GetAllFriends(int id);
        Task<FriendResponseModel> IsConfirmFriendAsync(ConfirmationFriendModel model);
    }
}
