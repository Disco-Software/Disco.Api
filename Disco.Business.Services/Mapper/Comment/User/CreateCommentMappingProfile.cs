using AutoMapper;
using Disco.Business.Interfaces.Dtos.Comment.User.CreateComment;

namespace Disco.Business.Services.Mapper.Comment.User
{
    public class CreateCommentMappingProfile : Profile
    {
        public CreateCommentMappingProfile()
        {
            CreateMap<CreateCommentRequestDto, Domain.Models.Models.Comment>()
                .ForMember(x => x.CommentDescription, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.PostId, options => options.MapFrom(x => x.PostId))
                .ForMember(x => x.Post, options => options.Ignore())
                .ForMember(x => x.Account, options => options.Ignore())
                .ForMember(x => x.AccountId, options => options.Ignore())
                .ForMember(x => x.Id, options => options.Ignore());

            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();
            CreateMap<Domain.Models.Models.Post, PostDto>();

            CreateMap<AccountDto, CreateCommentResponseDto>()
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => DateTime.UtcNow))
                .ForMember(x => x.Author, options => options.MapFrom(x => x))
                .ForMember(x => x.Post, options => options.Ignore());
        }
    }
}
