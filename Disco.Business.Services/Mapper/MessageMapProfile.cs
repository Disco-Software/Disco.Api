using AutoMapper;
using Disco.Business.Interfaces.Dtos.Chat;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Mappers
{
    public class MessageMapProfile : Profile
    {
        public MessageMapProfile()
        {
            CreateMap<string, Message>()
                .ForMember(o => o.Description, options => options.MapFrom(message => message))
                .ForMember(m => m.CreatedDate, options => options.MapFrom(date => DateTime.UtcNow))
                .ForMember(m => m.AccountId, options => options.Ignore())
                .ForMember(m => m.Account, options => options.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(u => u.Id, options => options.MapFrom(user => user.Id))
                .ForMember(u => u.Name, options => options.MapFrom(user => user.UserName));

            CreateMap<Account, AccountDto>()
                .ForMember(a => a.Id, options => options.MapFrom(account => account.Id))
                .ForMember(a => a.Photo, options => options.MapFrom(account => account.Photo))
                .ForMember(a => a.User, options => options.Ignore());

            CreateMap<Message, MessageDto>()
                .ForMember(md => md.Message, options => options.MapFrom(message => message.Description))
                .ForMember(md => md.MessageId, options => options.MapFrom(message => message.Id))
                .ForMember(md => md.Created, options => options.MapFrom(message => message.CreatedDate))
                .ForMember(md => md.Account, options => options.Ignore())
                .ForMember(md => md.GroupId, options => options.MapFrom(message => message.GroupId));
        }
    }
}
