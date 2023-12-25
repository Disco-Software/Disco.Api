using AutoMapper;
using Disco.Business.Interfaces.Dtos.Comment.User.UpdateComment;

namespace Disco.Business.Services.Mapper.Comment.User
{
    public class UpdateCommentMappingProfile : Profile
    {
        public UpdateCommentMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.Post, PostDto>();

            CreateMap<AccountDto, UpdateCommentResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x));
        }
    }
}
