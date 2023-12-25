using AutoMapper;
using Disco.Business.Interfaces.Dtos.StoryVideos.User.GetCurrentStoryVideos;

namespace Disco.Business.Services.Mapper.StoryVideo
{
    public class GetCurrentStoryVideosMappingProfile : Profile
    {
        public GetCurrentStoryVideosMappingProfile()
        {
            CreateMap<Domain.Models.Models.StoryVideo, GetCurrentStoryVideosResponseDto>();
        }
    }
}
