using Disco.Business.Dtos.Friends;
using Microsoft.AspNetCore.Mvc;
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
