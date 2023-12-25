using AutoMapper;
using Disco.Business.Interfaces.Dtos.StoryImages.User.GetCurrentStoryImages;

namespace Disco.Business.Services.Mapper.StoryImage
{
    public class GetCurrentStoryImageMappingProfile : Profile
    {
        public GetCurrentStoryImageMappingProfile()
        {
            CreateMap<Domain.Models.Models.StoryImage, GetCurrentStoryImageResponseDto>();
        }
    }
}
