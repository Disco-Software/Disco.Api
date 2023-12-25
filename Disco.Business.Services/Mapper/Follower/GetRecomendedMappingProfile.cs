using AutoMapper;
using Disco.Business.Interfaces.Dtos.Followers.User.GetRecomended;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Mapper.Follower
{
    public class GetRecomendedMappingProfile : Profile
    {
        public GetRecomendedMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Account, GetRecomendedResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
