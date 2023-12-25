using AutoMapper;
using Disco.Business.Interfaces.Dtos.PostImage.User.CreateImage;
using Disco.Business.Interfaces.Dtos.Posts.User.CreatePost;

namespace Disco.Business.Services.Mapper.Post.User
{
    public class CreatePostMappingProfile : Profile
    {
        public CreatePostMappingProfile()
        {
            CreateMap<CreatePostRequestDto, Domain.Models.Models.Post>()
                .ForMember(source => source.PostImages, opt => opt.Ignore())
                .ForMember(source => source.PostSongs, opt => opt.Ignore())
                .ForMember(source => source.PostVideos, opt => opt.Ignore());

            CreateMap<CreatePostRequestDto, CreatePostImageRequestDto>()
                .ForMember(source => source.ImageFile, opt => opt.Ignore());

            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Post, CreatePostResponseDto>()
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.Author, options => options.MapFrom(x => x.Account))
                .ForMember(x => x.CreatedAt, options => options.MapFrom(x => x.DateOfCreation))
                .ForMember(x => x.PostImages, options => options.MapFrom(x => x.PostImages))
                .ForMember(x => x.PostSongs, options => options.MapFrom(x => x.PostSongs))
                .ForMember(x => x.PostVideos, options => options.MapFrom(x => x.PostVideos));
        }
    }
}
