using AutoMapper;
using Disco.Business.Interfaces.Dtos.Stories.User.GetStory;

namespace Disco.Business.Services.Mapper.Story.User
{
    public class GetStoryMappingProfile : Profile
    {
        public GetStoryMappingProfile()
        {
            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Story, GetStoryResponseDto>()
                .ForMember(x => x.StoryImages, options => options.MapFrom(x => x.StoryImages))
                .ForMember(x => x.StoryVideos, options => options.MapFrom(x => x.StoryVideos))
                .ForMember(x => x.Account, options => options.MapFrom(x => x.Account))
                .ForMember(x => x.CreatedAt, options => options.MapFrom(x => x.DateOfCreation));
        }
    }
}
