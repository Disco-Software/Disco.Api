using AutoMapper;
using Disco.Business.Interfaces.Dtos.StoryImages.User.CreateStoryImage;

namespace Disco.Business.Services.Mapper.StoryImage
{
    public class CreateStoryImageMappingProfile : Profile
    {
        public CreateStoryImageMappingProfile()
        {
            CreateMap<CreateStoryImageRequestDto, Domain.Models.Models.StoryImage>()
                .ForMember(x => x.Source, options => options.Ignore())
                .ForMember(x => x.Id, options => options.Ignore())
                .ForMember(x => x.Story, options => options.Ignore())
                .ForMember(x => x.StoryId, options => options.Ignore());

            CreateMap<Domain.Models.Models.StoryImage, CreateStoryImageResponseDto>()
                .ForMember(x => x.Source, options => options.MapFrom(x => x.Source));
        }
    }
}
