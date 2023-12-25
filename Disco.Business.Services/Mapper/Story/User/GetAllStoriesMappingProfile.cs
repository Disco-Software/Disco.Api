using AutoMapper;
using Disco.Business.Interfaces.Dtos.Stories.User.GetAllStories;
using Disco.Business.Interfaces.Dtos.StoryImages.User.GetAllStoryImages;

namespace Disco.Business.Services.Mapper.Story.User
{
    public class GetAllStoriesMappingProfile : Profile
    {
        public GetAllStoriesMappingProfile()
        {
            CreateMap<Domain.Models.Models.PostImage, GetStoryImagesResponseDto>();

            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Story, GetAllStoriesResponseDto>()
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.StoryImages, options => options.MapFrom(x => x.StoryImages))
                .ForMember(x => x.StoryVideos, options => options.MapFrom(x => x.StoryVideos))
                .ForMember(x => x.CreateAt, options => options.MapFrom(x => x.DateOfCreation))
                .ForMember(x => x.Account, options => options.MapFrom(x => x.Account));
        }
    }
}
