using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Friends;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Business.Dtos.Messages;

namespace Disco.Business.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public MessageService(
            IMapper mapper,
            IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<MessageResponseDto> CreateMessageAsync(User user, MessageResponseDto model)
        {
            var currentUserMessage = new Message
            {
                UserProfile = user.Profile,
                CreateDate = model.CreateDate,
                MessageText = model.MessageText,
            };
            return new MessageResponseDto
            {
                UserProfile = user.Profile,
                CreateDate = model.CreateDate,
                MessageText = model.MessageText,
            };
        }

        public async Task DeleteMessage(int id) =>
            await _messageRepository.Remove(id);

        public async Task<List<MessageResponseDto>> GetAllMessages(GetAllMessagesDto dto)
        {
            var messages = await _messageRepository.GetAllMessages(dto.UserId, dto.PageNumber, dto.PageSize);
            var messageModels = new List<MessageResponseDto>();

            foreach (var message in messages)
            {
                var messageModel = new MessageResponseDto
                {
                    UserProfile = message.UserProfile,
                    CreateDate = message.CreateDate,
                    MessageText = message.MessageText,
                };

                messageModels.Add(messageModel);
            }

            return messageModels;
        }

        public async Task<MessageResponseDto> GetMessageAsync(int id)
        {
            var message = await _messageRepository.Get(id);

            if (message == null)
                throw new Exception("Message not found");

            var userProfileModel = _mapper.Map<ProfileDto>(message.UserProfile);

            return new MessageResponseDto
            {
                UserProfile = message.UserProfile,
                CreateDate = message.CreateDate,
                MessageText = message.MessageText,
            };
        }
    }
}
