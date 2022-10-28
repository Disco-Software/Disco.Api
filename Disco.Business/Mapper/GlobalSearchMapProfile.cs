using AutoMapper;
using Disco.Business.Dtos.Search;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Mapper
{
    public class GlobalSearchMapProfile : Profile
    {
        public GlobalSearchMapProfile()
        {
            CreateMap<IEnumerable<User>, GlobalSearchResponseDto>()
                .ForMember(p => p.Posts, opt => opt.Ignore())
                .ForMember(p => p.Accounts, opt => opt.Ignore());
        }
    }
}
