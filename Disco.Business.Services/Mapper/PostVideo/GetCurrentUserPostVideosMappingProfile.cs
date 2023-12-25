using AutoMapper;
using Disco.Business.Interfaces.Dtos.PostVideo.User.CreatePostVideo;

namespace Disco.Business.Services.Mapper.PostVideo
{
    public class GetCurrentUserPostVideosMappingProfile : Profile
    {
        public GetCurrentUserPostVideosMappingProfile()
        {
            CreateMap<Domain.Models.Models.PostVideo, CreatePostVideoResponseDto>();
        }
    }
}
