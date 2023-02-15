using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Services
{
    public class AccountGroupService : IAccountGroupService
    {
        private readonly IAccountGroupRepository _accountGroupRepository;
        private readonly IMapper _mapper;

        public AccountGroupService(
            IAccountGroupRepository accountGroupRepository,
            IMapper mapper)
        {
            _accountGroupRepository = accountGroupRepository;
            _mapper = mapper;
        }

        public async Task<AccountGroup> CreateAsync(Account account, Group group)
        {
            var accountGroup = _mapper.Map<AccountGroup>(account);
            accountGroup.Group = group;
            accountGroup.GroupId = group.Id;

            group.AccountGroups.Add(accountGroup);

            await _accountGroupRepository.CreateAsync(accountGroup);
            
            return accountGroup;
        }

        public Task DeleteAsync(AccountGroup accountGroup)
        {
            return _accountGroupRepository.DeleteAsync(accountGroup);
        }

        public async Task<AccountGroup> GetAsync(int id)
        {
            return await _accountGroupRepository.GetAsync(id);
        }
    }
}
