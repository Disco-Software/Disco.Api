using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IFriendRepository
    {
        Task<int> AddAsync(Friend currentUserFriend);
        Task<Friend> Get(int id);
        Task Remove(int id);
        Task<List<Friend>> GetAllFriends(int id, int pageNumber, int pageSize);
    }
}
