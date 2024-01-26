using AutoMapper;
using Disco.Domain.Events; 

namespace Disco.Business.Services.Mapper.Shared
{
    public class CreatedPostEventMappingProfile : Profile
    {
        public CreatedPostEventMappingProfile()
        {
            CreateMap<Domain.Models.Models.Account, Domain.Events.Dto.AccountDto>();
            CreateMap<Domain.Models.Models.User, Domain.Events.Dto.UserDto>();
            CreateMap<Domain.Models.Models.UserFollower, Domain.Events.Dto.UserFollowerDto>();
            CreateMap<Domain.Models.Models.Comment, Domain.Events.Dto.CommentDto>();
            CreateMap<Domain.Models.Models.Like, Domain.Events.Dto.LikeDto>();
            CreateMap<Domain.Models.Models.PostImage, Domain.Events.Dto.PostImageDto>();
            CreateMap<Domain.Models.Models.PostSong, Domain.Events.Dto.PostSongDto>();
            CreateMap<Domain.Models.Models.PostVideo, Domain.Events.Dto.PostVideoDto>();
            CreateMap<Domain.Models.Models.Post, Domain.Events.Events.PostCreatedEvent>();
        }
    }
}
