﻿using AutoMapper;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Mapper
{
    public class GroupMapProfile : Profile
    {
        public GroupMapProfile()
        {
            CreateMap<Account, AccountGroup>()
                .ForMember(ag => ag.Group, options => options.Ignore())
                .ForMember(ag => ag.Account, options => options.MapFrom(a => a))
                .ForMember(ag => ag.AccountId, options => options.MapFrom(a => a.Id))
                .ForMember(ag => ag.GroupId, options => options.Ignore());
        }
    }
}