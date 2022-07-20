using Disco.Business.Dto;
using Disco.Business.Dto;
using Disco.Business.Dto.Friends;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IFriendService
    {
        Task<IActionResult> CreateFriendAsync(CreateFriendDto model);
        Task DeleteFriend(int id);
        Task<IActionResult> GetFriendAsync(int id);
        Task<IActionResult> GetAllFriends(int id);
    }
}
