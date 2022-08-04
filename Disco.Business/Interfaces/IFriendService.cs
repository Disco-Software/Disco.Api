using Disco.Business.Dtos.Friends;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IFriendService
    {
        Task<FriendResponseDto> CreateFriendAsync(User user, User friend, CreateFriendDto modelel);
        Task DeleteFriend(int id);
        Task<FriendResponseDto> GetFriendAsync(int id);
        Task<List<FriendResponseDto>> GetAllFriends(GetAllFriendsDto dto);
    }
}
