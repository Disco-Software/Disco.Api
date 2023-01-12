using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
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

            await _messageRepository.CreateAsync(message);

            return message;
        }

        public async Task DeleteAsync(Message message)
        {
            await _messageRepository.DeleteAsync(message.Id);
        }

        public async Task<List<Message>> GetAllAsync(int groupId, int pageNumber, int pageSize)
        {
            return await _messageRepository.GetAllAsync(groupId, groupId, pageNumber, pageSize);
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _messageRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Message message)
        {
           await _messageRepository.UpdateAsync(message);
        }
    }
}
