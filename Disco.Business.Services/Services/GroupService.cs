using AutoMapper;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Group = Disco.Domain.Models.Models.Group;

namespace Disco.Business.Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IAccountGroupRepository _accountGroupRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GroupService(
            IGroupRepository groupRepository,
            IAccountGroupRepository accountGroupRepository,
            IAccountRepository accountRepository,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _accountGroupRepository = accountGroupRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Models.Models.Group> CreateAsync()
        {
            var group = new Group();
            group.Name = Guid.NewGuid().ToString();
            group.AccountGroups = new List<AccountGroup>();
            group.Messages = new List<Message>();
            
            await _groupRepository.CreateAsync(group);

            return group;
        }


        public async Task DeleteAsync(Group group)
        {
            await _groupRepository.DeleteAsync(group);
        }

        public async Task<IEnumerable<Group>> GetAllAsync(int id, int pageNumber, int pageSize)
        {
            var groups = await _groupRepository.GetAllAsync(id, pageNumber, pageSize);

            return groups;
        }

        public async Task<Group> GetAsync(int id)
        {
            return await _groupRepository.GetAsync(id);
        }

        public async Task<Group> UpdateAsync(Group group)
        {
            if (group == null)
                throw new NullReferenceException();

            await _groupRepository.UpdateAsync(group);

            return group;
        }
    }
}
