using AutoMapper;
using Disco.Business.Interfaces.Dtos.Like.User.CreateLike;

namespace Disco.Business.Services.Mapper.Like.User
{
    public class CreateLikeMappingProfile : Profile
    {
        public CreateLikeMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Account, Domain.Models.Models.Like>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x))
                .ForMember(x => x.AccountId, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.Post, options => options.Ignore())
                .ForMember(x => x.PostId, options => options.Ignore())
                .ForMember(x => x.Id, options => options.Ignore());

            CreateMap<Domain.Models.Models.Post, PostDto>()
                .ForMember(x => x.PostId, options => options.MapFrom(x => x.Id));

            CreateMap<Domain.Models.Models.Like, CreateLikeResponseDto>()
                .ForMember(x => x.Post, options => options.MapFrom(x => x.Post))
                .ForMember(x => x.Account, options => options.MapFrom(x => x.Account))
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id));
        }
    }
}
