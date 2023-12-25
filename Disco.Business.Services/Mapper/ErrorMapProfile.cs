using AutoMapper;
using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Dtos.Errors.Admin.Error;
using Disco.Business.Utils.Exceptions;

namespace Disco.Business.Services.Mapper
{
    public class ErrorMapProfile : Profile
    {
        public ErrorMapProfile()
        {
            CreateMap<ResourceNotFoundException, ErrorDto>()
                .ForMember(x => x.ErrorMessages, options => options.MapFrom(ex => ex.Errors.Select(kv => new ErrorMessage(kv.Key, kv.Value)).ToList()));
            CreateMap<InvalidPostDataException, ErrorDto>()
                .ForMember(x => x.ErrorMessages, options => options.MapFrom(ex => ex.Errors.Select(kv => new ErrorMessage (kv.Key, kv.Value )).ToList()));
            CreateMap<InvalidPasswordException, ErrorDto>()
                .ForMember(x => x.ErrorMessages, options => options.MapFrom(ex => ex.Errors.Select(kv => new ErrorMessage (kv.Key, kv.Value)).ToList()));
            CreateMap<InvalidRoleException, ErrorDto>()
                .ForMember(x => x.ErrorMessages, options => options.MapFrom(ex => ex.Errors.Select(kv => new ErrorMessage (kv.Key, kv.Value)).ToList()));
        }
    }
}
