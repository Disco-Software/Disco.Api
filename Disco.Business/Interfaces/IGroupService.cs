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
        Task<Domain.Models.Group> CreateAsync();
        Task DeleteAsync(Group group, Account account);
        Task<IEnumerable<Group>> GetAllAsync(int id, int pageNumber, int pageSize);
        Task<Group> GetAsync(int id);
        Task<Group> UpdateAsync(Group group);
    }
}
