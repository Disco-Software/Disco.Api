using AutoMapper;
using Disco.BLL.Dto;
using Disco.BLL.Dto;
using Disco.BLL.Dto.Authentication;
using Disco.BLL.Dto.Facebook;
using Disco.BLL.Dto.Friends;
using Disco.BLL.Dto.Images;
using Disco.BLL.Dto.Posts;
using Disco.BLL.Dto.Roles;
using Disco.BLL.Dto.Songs;
using Disco.BLL.Dto.Stories;
using Disco.BLL.Dto.StoryImages;
using Disco.BLL.Dto.StoryVideos;
using Disco.BLL.Dto.Videos;
using Disco.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Disco.BLL.Mapper
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
            CreateMap<DAL.Models.Profile, ProfileDto>();
            CreateMap<User, UserResponseDto>()
                .ForMember(source => source.RefreshToken, opt => opt.Ignore())
                .ForMember(source => source.AccessToken, opt => opt.Ignore());
            CreateMap<DAL.Models.Profile, ProfileDto>();
            CreateMap<ProfileDto, FriendResponseDto>()
                .ForMember(source => source.UserProfile, opt => opt.Ignore())
                .ForMember(source => source.FriendProfile, opt => opt.Ignore())
                .ForMember(source => source.FriendId, opt => opt.Ignore());
            CreateMap<CreateRoleDto, Role>();
            CreateMap<FacebookDto, User>()
                .ForMember(source => source.UserName, f => f.Ignore())
                .ForMember(source => source.Email, e => e.Ignore());
        }
    }
}
