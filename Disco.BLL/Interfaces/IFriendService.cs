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
        Task<IActionResult> CreateFriendAsync(CreateFriendModel model);
        Task DeleteFriend(int id);
        Task<IActionResult> GetFriendAsync(int id);
        Task<IActionResult> GetAllFriends(int id);
    }
}
