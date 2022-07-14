using AutoMapper;
using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.BLL.Models.Authentication;
using Disco.BLL.Models.Facebook;
using Disco.BLL.Models.Friends;
using Disco.BLL.Models.Images;
using Disco.BLL.Models.Posts;
using Disco.BLL.Models.Roles;
using Disco.BLL.Models.Songs;
using Disco.BLL.Models.Stories;
using Disco.BLL.Models.StoryImages;
using Disco.BLL.Models.StoryVideos;
using Disco.BLL.Models.Videos;
using Disco.DAL.Entities;
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
            CreateMap<CreatePostModel, Post>()
                .ForMember(source => source.PostImages, opt => opt.Ignore())
                .ForMember(source => source.PostSongs, opt => opt.Ignore())
                .ForMember(source => source.PostVideos, opt => opt.Ignore());
            CreateMap<Post, PostResponseModel>();
            CreateMap<CreateImageModel, PostImage>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            CreateMap<CreateSongModel, PostSong>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            CreateMap<CreateVideoModel, PostVideo>()
                .ForMember(source => source.VideoSource, opt => opt.Ignore());
            CreateMap<CreateStoryModel,Story>()
                .ForMember(source => source.StoryImages, opt => opt.Ignore())
                .ForMember(source => source.StoryVideos, opt => opt.Ignore())
                .ForMember(source => source.DateOfCreation, opt => opt.Ignore());
            CreateMap<CreateStoryImageModel, StoryImage>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            CreateMap<CreateStoryVideoModel, StoryVideo>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            CreateMap<RegistrationModel, User>();
            CreateMap<CreateFriendModel, Friend>();
            CreateMap<DAL.Entities.Profile, ProfileModel>();
            CreateMap<User, UserResponseModel>()
                .ForMember(source => source.RefreshToken, opt => opt.Ignore())
                .ForMember(source => source.AccessToken, opt => opt.Ignore());
            CreateMap<DAL.Entities.Profile, ProfileModel>();
            CreateMap<ProfileModel, FriendResponseModel>()
                .ForMember(source => source.UserProfile, opt => opt.Ignore())
                .ForMember(source => source.FriendProfile, opt => opt.Ignore())
                .ForMember(source => source.FriendId, opt => opt.Ignore());
            CreateMap<CreateRoleModel, Role>();
            CreateMap<FacebookModel, User>()
                .ForMember(source => source.UserName, f => f.Ignore())
                .ForMember(source => source.Email, e => e.Ignore());
        }
    }
}
