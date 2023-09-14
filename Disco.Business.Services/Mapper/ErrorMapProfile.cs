using AutoMapper;
using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Dtos.Errors;
using Disco.Business.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Mapper
{
    public class ErrorMapProfile : Profile
    {
        public ErrorMapProfile()
        {
            CreateMap<ResourceNotFoundException, ErrorDto>()
                .ForMember(x => x.ErrorMessages, options => options.MapFrom(ex => ex.Errors.Select(kv => new ErrorMessage { Name = kv.Key, Message = kv.Value }).ToList()));
            CreateMap<InvalidPostDataException, ErrorDto>()
                .ForMember(x => x.ErrorMessages, options => options.MapFrom(ex => ex.Errors.Select(kv => new ErrorMessage { Name = kv.Key, Message = kv.Value }).ToList()));
            CreateMap<InvalidPasswordException, ErrorDto>()
                .ForMember(x => x.ErrorMessages, options => options.MapFrom(ex => ex.Errors.Select(kv => new ErrorMessage { Name = kv.Key, Message = kv.Value }).ToList()));
            CreateMap<InvalidRoleException, ErrorDto>()
                .ForMember(x => x.ErrorMessages, options => options.MapFrom(ex => ex.Errors.Select(kv => new ErrorMessage { Name = kv.Key, Message = kv.Value }).ToList()));
        }
    }
}
