using AutoMapper;
using Disco.Business.Interfaces.Dtos.Images.User.GetPostImages;

namespace Disco.Business.Services.Mapper.PostImage
{
    public class GetPostImagesMappingProfile : Profile
    {
        public GetPostImagesMappingProfile()
        {
            CreateMap<Domain.Models.Models.PostImage, GetPostImagesResponseDto>();
        }
    }
}
