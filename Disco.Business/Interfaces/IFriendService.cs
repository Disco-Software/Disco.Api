using Disco.Business.Dtos.Friends;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IFollowerService
    {
        Task<FriendResponseDto> CreateAsync(User user, User friend, CreateFollowerDto dto);
        Task DeleteFriend(int id);
        Task<FriendResponseDto> GetAsync(int id);
        Task<List<FriendResponseDto>> GetAllFollowers(GetAllFriendsDto dto);
    }
}
