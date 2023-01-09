using AutoMapper;
using Disco.Business.Dtos.Chat;
using Disco.Business.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Disco.Domain.Models.Group;

namespace Disco.Business.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(
            IGroupRepository groupRepository,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Models.Group> CreateAsync(Account userAccount, Account followerAccount)
        {
            var group = _mapper.Map<Domain.Models.Group>(userAccount);
            group.Accounts.Add(followerAccount);
            group.Accounts.Add(userAccount);

            await _groupRepository.CreateAsync(group);

            return group;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetAllAsync(int id, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<GroupResponseDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupResponseDto> UpdateAsync(Group group)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Domain.Models.Group>> IGroupService.GetAllAsync(int id, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
