using AutoMapper;
using Disco.Business.Interfaces.Dtos.Post.User.GetCurrentUserPosts;

namespace Disco.Business.Services.Mapper.Post.User
{
    public class GetCurrentUserPostsMappingProfile : Profile
    {
        public GetCurrentUserPostsMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Post, GetCurrentUserPostsResponseDto>()
                .ForMember(x => x.Description, options => options.MapFrom(x => x.Description))
                .ForMember(x => x.Author, options => options.MapFrom(x => x.Account))
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => x.DateOfCreation))
                .ForMember(x => x.Likes, options => options.MapFrom(x => x.Likes.Count))
                .ForMember(x => x.Comments, options => options.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.CreatedDate, options => options.MapFrom(x => x.DateOfCreation))
                .ForMember(x => x.PostImages, options => options.MapFrom(x => x.PostImages))
                .ForMember(x => x.PostSongs, options => options.MapFrom(x => x.PostSongs))
                .ForMember(x => x.PostVideos, options => options.MapFrom(x => x.PostVideos));
        }
    }
}
