using AutoMapper;
using Disco.Business.Dtos.Chat;
using Disco.Business.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Disco.Domain.Models.Group;

namespace Disco.Business.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IAccountGroupRepository _accountGroupRepository;
        private readonly IMapper _mapper;

        public GroupService(
            IGroupRepository groupRepository,
            IAccountGroupRepository accountGroupRepository,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _accountGroupRepository = accountGroupRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Models.Group> CreateAsync()
        {
            var group = new Group();
            group.Name = Guid.NewGuid().ToString();
            group.AccountGroups = new List<AccountGroup>();
            group.Messages = new List<Message>();
            
            await _groupRepository.CreateAsync(group);

            return group;
        }

        public async Task DeleteAsync(Group group, Account account)
        {
            var accountGroup = group.AccountGroups
                .Where(group => group.AccountId == account.Id)
                .FirstOrDefault();

            account.AccountGroups.Remove(accountGroup);

            if(group.AccountGroups.Count < 2)
            {
                foreach (var userAccount in group.AccountGroups)
                    await _accountGroupRepository.DeleteAsync(accountGroup);
            }

            await _groupRepository.DeleteAsync(group);
        }

        public async Task<IEnumerable<Group>> GetAllAsync(int id, int pageNumber, int pageSize)
        {
            return await _groupRepository.GetAllAsync(id, pageNumber, pageSize);
        }

        public async Task<Group> GetAsync(int id)
        {
            return await _groupRepository.GetAsync(id);
        }

        public async Task<Group> UpdateAsync(Group group)
        {
            await _groupRepository.UpdateAsync(group);

            return group;
        }
    }
}
