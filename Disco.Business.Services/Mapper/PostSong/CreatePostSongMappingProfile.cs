using AutoMapper;
using Disco.Business.Interfaces.Dtos.PostSong.User.CreatePostSong;

namespace Disco.Business.Services.Mapper.PostSong
{
    public class CreatePostSongMappingProfile : Profile
    {
        public CreatePostSongMappingProfile()
        {
            CreateMap<Domain.Models.Models.PostSong, CreatePostSongResponseDto>()
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.Artist, options => options.MapFrom(x => new ArtistDto(x.ExecutorName)))
                .ForMember(x => x.Source, options => options.MapFrom(x => x.Source))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name));
        }
    }
}
