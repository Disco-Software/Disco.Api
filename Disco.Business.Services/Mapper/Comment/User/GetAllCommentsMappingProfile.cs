using AutoMapper;
using Disco.Business.Interfaces.Dtos.Comment.User.GetAllComments;

namespace Disco.Business.Services.Mapper.Comment.User
{
    public class GetAllCommentsMappingProfile : Profile
    {
        public GetAllCommentsMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.Post, PostDto>();

            CreateMap<AccountDto, GetAllCommentsResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
