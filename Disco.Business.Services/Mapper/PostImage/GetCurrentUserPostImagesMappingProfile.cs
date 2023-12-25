using AutoMapper;
using Disco.Business.Interfaces.Dtos.Images.User.GetPostImages;

namespace Disco.Business.Services.Mapper.PostImage
{
    public class GetCurrentUserPostImagesMappingProfile : Profile
    {
        public GetCurrentUserPostImagesMappingProfile()
        {
            CreateMap<Domain.Models.Models.PostImage, GetPostImagesResponseDto>();
        }
    }
}
