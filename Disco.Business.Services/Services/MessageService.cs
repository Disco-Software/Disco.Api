using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.IdentityModel.Tokens;
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
            if (textMessage.IsNullOrEmpty() && string.IsNullOrWhiteSpace(textMessage))
                throw new NullReferenceException(nameof(textMessage));

            var message = _mapper.Map<Message>(textMessage);
            message.Account = account;
            message.AccountId = account.Id;
            message.Group = group;
            message.GroupId = group.Id;

            message.Group.Messages.Add(message);

            await _messageRepository.CreateAsync(message);

            return message;
        }

        public async Task DeleteAsync(Message message)
        {
            message.Account.Messages.Remove(message);
            message.Group.Messages.Remove(message);

            await _messageRepository.DeleteAsync(message);
        }

        public async Task<List<Message>> GetAllAsync(int groupId, int pageNumber, int pageSize)
        {
            return await _messageRepository.GetAllAsync(groupId, pageNumber, pageSize);
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _messageRepository.GetAsync(id);
        }

        public IEnumerable<Message> GetGroupMessages(int id, int pageNumber, int pageSize)
        {
            return _messageRepository.GetAllGroupMessages(id, pageNumber, pageSize);
        }

        public async Task UpdateAsync(Message message)
        {
           await _messageRepository.UpdateAsync(message);
        }
    }
}
