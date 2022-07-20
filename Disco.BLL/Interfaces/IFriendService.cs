using Disco.BLL.Dto;
using Disco.BLL.Dto;
using Disco.BLL.Dto.Friends;
using Disco.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IFriendService
    {
        Task<IActionResult> CreateFriendAsync(CreateFriendDto model);
        Task DeleteFriend(int id);
        Task<IActionResult> GetFriendAsync(int id);
        Task<IActionResult> GetAllFriends(int id);
    }
}
