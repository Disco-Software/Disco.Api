using AutoMapper;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Mappers
{
    public class GroupMapProfile : Profile
    {
        public GroupMapProfile()
        {
            CreateMap<Account, AccountGroup>()
                .ForMember(ag => ag.Id, options => options.Ignore())
                .ForMember(ag => ag.Group, options => options.Ignore())
                .ForMember(ag => ag.Account, options => options.MapFrom(a => a))
                .ForMember(ag => ag.AccountId, options => options.MapFrom(a => a.Id))
                .ForMember(ag => ag.GroupId, options => options.Ignore());
            CreateMap<AccountGroup, Group>()
                .ForMember(ag => ag.AccountGroups, options => options.Ignore())
                .ForMember(ag => ag.Messages, options => options.Ignore())
                .ForMember(ag => ag.Name, options => options.MapFrom(ag => Guid.NewGuid().ToString()));
        }
    }
}
