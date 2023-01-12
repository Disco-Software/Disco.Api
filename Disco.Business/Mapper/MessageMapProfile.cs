using AutoMapper;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Mapper
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
        }
    }
}
