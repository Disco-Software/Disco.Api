using AutoMapper;
using Disco.Business.Interfaces.Dtos.Stories.User.CreateStory;

namespace Disco.Business.Services.Mapper.Story.User
{
    public class CreateStoryMappingProfile : Profile
    {
        public CreateStoryMappingProfile()
        {
            CreateMap<CreateStoryRequestDto, Domain.Models.Models.Story>()
                .ForMember(x => x.Id, options => options.Ignore())
                .ForMember(x => x.Account, options => options.Ignore())
                .ForMember(x => x.StoryVideos, options => options.Ignore())
                .ForMember(x => x.StoryImages, options => options.Ignore());

            CreateMap<Domain.Models.Models.User, UserDto>();
            CreateMap<Domain.Models.Models.Account, AccountDto>();

            CreateMap<Domain.Models.Models.Story, CreateStoryResponseDto>()
                .ForMember(x => x.Account, options => options.MapFrom(x => x.Account))
                .ForMember(x => x.StoryVideos, options => options.MapFrom(x => x.StoryVideos))
                .ForMember(x => x.StoryImages, options => options.MapFrom(x => x.StoryImages))
                .ForMember(x => x.CreatedAt, options => options.MapFrom(x => x.DateOfCreation));
        }
    }
}
