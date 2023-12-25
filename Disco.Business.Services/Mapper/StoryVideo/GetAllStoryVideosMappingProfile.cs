using AutoMapper;
using Disco.Business.Interfaces.Dtos.StoryVideos.User.GetAllStoryVideos;

namespace Disco.Business.Services.Mapper.StoryVideo
{
    public class GetAllStoryVideosMappingProfile : Profile
    {
        public GetAllStoryVideosMappingProfile()
        {
            CreateMap<Domain.Models.Models.StoryVideo, GetStoryVideosResponseDto>()
                .ForMember(x => x.Source, options => options.MapFrom(x => x.Source));
        }
    }
}
