using AutoMapper;
using Disco.Business.Interfaces.Dtos.PostSong.User.GetPostSongs;

namespace Disco.Business.Services.Mapper.PostSong
{
    public class GetPostSongsMappingProfile : Profile
    {
        public GetPostSongsMappingProfile()
        {
            CreateMap<Domain.Models.Models.PostSong, GetPostSongResponseDto>()
                .ForMember(x => x.Artist, options => options.MapFrom(x => new ArtistDto(x.ExecutorName)));
        }
    }
}
