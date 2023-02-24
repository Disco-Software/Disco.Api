using AutoMapper;
using Disco.Business.Interfaces.Dtos.Search;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Services.Mappers
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
