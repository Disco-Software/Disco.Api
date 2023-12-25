using AutoMapper;
using Disco.Business.Interfaces.Dtos.PostSong.User.CreatePostSong;

namespace Disco.Business.Services.Mapper.PostSong
{
    public class GetCurrentUserPostSongsMappingProfile : Profile
    {
        public GetCurrentUserPostSongsMappingProfile()
        {
            CreateMap<Domain.Models.Models.PostSong, CreatePostSongResponseDto>()
                .ForMember(x => x.Artist, options => options.MapFrom(x => new ArtistDto(x.ExecutorName)));
        }
    }
}
