using AutoMapper;
using Disco.Business.Interfaces.Dtos.StoryVideos.User.CreateStoryVideo;

namespace Disco.Business.Services.Mapper.StoryVideo
{
    public class CreateStoryVideoMappingProfile : Profile
    {
        public CreateStoryVideoMappingProfile()
        {
            CreateMap<Domain.Models.Models.StoryVideo, CreateStoryVideoResponseDto>()
                .ForMember(x => x.Source, options => options.MapFrom(x => x.Source));
        }
    }
}
