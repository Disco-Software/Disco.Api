using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(
            IMessageRepository messageRepository,
            IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<Message> CreateAsync(string textMessage, Account account, Group group)
        {
            var message = _mapper.Map<Message>(textMessage);
            message.Account = account;
            message.AccountId = account.Id;
            message.Group = group;
            message.GroupId = group.Id;

            message.Group.Messages.Add(message);

            await _messageRepository.AddAsync(message);

            return message;
        }

        public async Task DeleteAsync(Message message)
        {
            message.Account.Messages.Remove(message);
            message.Group.Messages.Remove(message);

            await _messageRepository.Remove(message);
        }

        public async Task<List<Message>> GetAllAsync(int groupId, int pageNumber, int pageSize)
        {
            return await _messageRepository.GetAll(pageNumber, pageSize)
                .Where(message => message.GroupId == groupId)
                .ToListAsync();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _messageRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Message message)
        {
           await _messageRepository.UpdateAsync(message);
        }
    }
}
