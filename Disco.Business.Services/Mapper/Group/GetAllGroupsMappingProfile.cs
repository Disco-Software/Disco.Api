using AutoMapper;
using Disco.Business.Interfaces.Dtos.Group.User.GetAllGroups;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Mapper.Group
{
    public class GetAllGroupsMappingProfile : Profile
    {
        public GetAllGroupsMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, AccountGroup>()
                .ForMember(ag => ag.Id, options => options.Ignore())
                .ForMember(ag => ag.Group, options => options.MapFrom(x => new Domain.Models.Models.Group()))
                .ForMember(ag => ag.Account, options => options.MapFrom(a => a))
                .ForMember(ag => ag.AccountId, options => options.MapFrom(a => a.Id))
                .ForMember(ag => ag.GroupId, options => options.Ignore());
            CreateMap<AccountGroup, Domain.Models.Models.Group>()
                .ForMember(ag => ag.AccountGroups, options => options.Ignore())
                .ForMember(ag => ag.Messages, options => options.Ignore())
                .ForMember(ag => ag.Name, options => options.MapFrom(ag => Guid.NewGuid().ToString()));

            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Group, GetAllGroupsResponseDto>()
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.Accounts, options => options.Ignore());
        }
    }
}
