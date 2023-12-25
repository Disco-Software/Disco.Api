using AutoMapper;
using Disco.Business.Interfaces.Dtos.PostVideo.User.CreatePostVideo;

namespace Disco.Business.Services.Mapper.PostVideo
{
    public class CreatePostVideoMappingProfile : Profile
    {
        public CreatePostVideoMappingProfile()
        {
            CreateMap<Domain.Models.Models.PostVideo, CreatePostVideoRequestDto>();
        }
    }
}
