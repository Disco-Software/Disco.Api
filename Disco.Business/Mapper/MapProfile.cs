using Disco.Business.Dtos.Authentication;
using Disco.Business.Dtos.Facebook;
using Disco.Business.Dtos.Friends;
using Disco.Business.Dtos.Google;
using Disco.Business.Dtos.Images;
using Disco.Business.Dtos.Posts;
using Disco.Business.Dtos.Roles;
using Disco.Business.Dtos.Search;
using Disco.Business.Dtos.Songs;
using Disco.Business.Dtos.Stories;
using Disco.Business.Dtos.StoryImages;
using Disco.Business.Dtos.StoryVideos;
using Disco.Business.Dtos.Videos;
using Disco.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace Disco.Business.Mapper
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            CreateMap<CreatePostDto, Post>()
                .ForMember(source => source.PostImages, opt => opt.Ignore())
                .ForMember(source => source.PostSongs, opt => opt.Ignore())
                .ForMember(source => source.PostVideos, opt => opt.Ignore());
            CreateMap<Post, PostResponseDto>();
            CreateMap<CreateImageDto, PostImage>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            CreateMap<CreateSongDto, PostSong>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            CreateMap<CreateVideoDto, PostVideo>()
                .ForMember(source => source.VideoSource, opt => opt.Ignore());
            CreateMap<CreateStoryDto,Story>()
                .ForMember(source => source.StoryImages, opt => opt.Ignore())
                .ForMember(source => source.StoryVideos, opt => opt.Ignore())
                .ForMember(source => source.DateOfCreation, opt => opt.Ignore());
            CreateMap<CreateStoryImageDto, StoryImage>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            CreateMap<CreateStoryVideoDto, StoryVideo>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            CreateMap<RegistrationDto, User>();
            CreateMap<CreateFriendDto, Friend>();
            CreateMap<Account, ProfileDto>();
            CreateMap<User, UserResponseDto>()
                .ForMember(source => source.RefreshToken, opt => opt.Ignore())
                .ForMember(source => source.AccessToken, opt => opt.Ignore());
            CreateMap<Account, ProfileDto>();
            CreateMap<ProfileDto, FriendResponseDto>()
                .ForMember(source => source.UserProfile, opt => opt.Ignore())
                .ForMember(source => source.FriendProfile, opt => opt.Ignore())
                .ForMember(source => source.FriendId, opt => opt.Ignore());
            CreateMap<CreateRoleDto, Role>();
            CreateMap<FacebookDto, User>()
                .ForMember(source => source.UserName, f => f.Ignore())
                .ForMember(source => source.Email, e => e.Ignore());
            CreateMap<GoogleLogInDto, User>();
            CreateMap<IEnumerable<User>, GlobalSearchResponseDto>()
                .ForMember(p => p.Posts, opt => opt.Ignore())
                .ForMember(p => p.Profile, opt => opt.Ignore());
        }
    }
}
