using AutoMapper;
using Disco.Business.Interfaces.Dtos.StoryImages.User.GetAllStoryImages;

namespace Disco.Business.Services.Mapper.StoryImage
{
    public class GetStoryImagesMappingProfile : Profile
    {
        public GetStoryImagesMappingProfile()
        {
            CreateMap<Domain.Models.Models.StoryImage, GetStoryImagesResponseDto>();
        }
    }
}
