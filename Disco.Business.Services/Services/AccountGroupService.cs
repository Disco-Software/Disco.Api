using AutoMapper;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Guards;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

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

            DefaultGuard.ArgumentNull(_accountGroupRepository);
            DefaultGuard.ArgumentNull(_mapper);
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

        public async Task<AccountGroup> GetAsync(int accountId, int groupId)
        {
            return await _accountGroupRepository.GetAsync(groupId, accountId);
        }
    }
}
