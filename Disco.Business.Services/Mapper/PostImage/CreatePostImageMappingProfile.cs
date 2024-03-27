using AutoMapper;
using Disco.Business.Interfaces.Dtos.Images.User.CreateImage;
using Disco.Business.Interfaces.Dtos.PostImage.User.CreateImage;

namespace Disco.Business.Services.Mapper.PostImage
{
    public class CreatePostImageMappingProfile : Profile
    {
        public CreatePostImageMappingProfile()
        {
            CreateMap<CreatePostImageRequestDto, Domain.Models.Models.PostImage>()
                .ForMember(source => source.Source, opt => opt.Ignore())
                .ForMember(source => source.Post, opt => opt.Ignore())
                .ForMember(source => source.PostId, opt => opt.Ignore())
                .ForMember(source => source.PostId, opt => opt.Ignore());

            CreateMap<Domain.Models.Models.PostImage, CreatePostImageResponseDto>()
                .ForMember(x => x.Source, options => options.MapFrom(x => x.Source));
        }
    }
}
