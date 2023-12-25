using AutoMapper;
using Disco.Business.Interfaces.Dtos.PostVideo.User.GetCurrentUserPostVideos;

namespace Disco.Business.Services.Mapper.PostVideo
{
    public class GetPostVideosMappingProfile : Profile
    {
        public GetPostVideosMappingProfile()
        {
            CreateMap<Domain.Models.Models.PostVideo, GetPostVideosMappingProfile>();
        }
    }
}
