using Disco.Business.Dtos.Chat;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Disco.Domain.Models.Group;

namespace Disco.Business.Interfaces
{
    public interface IGroupService
    {
        Task<Domain.Models.Group> CreateAsync(Account userAccount, Account followerAccount);
        Task DeleteAsync(int id);
        Task<IEnumerable<Group>> GetAllAsync(int id, int pageNumber, int pageSize);
        Task<GroupResponseDto> GetAsync(int id);
        Task<GroupResponseDto> UpdateAsync(Group group);
    }
}
