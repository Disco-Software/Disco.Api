using AutoMapper;
using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.BLL.Models.Authentication;
using Disco.BLL.Models.Facebook;
using Disco.BLL.Models.Friends;
using Disco.BLL.Models.Posts;
using Disco.BLL.Models.Stories;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Mapper
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            CreateMap<CreatePostModel, Post>()
                .ForSourceMember(source => source.PostImages, opt => opt.DoNotValidate())
                .ForSourceMember(source => source.PostSongs, opt => opt.DoNotValidate())
                .ForSourceMember(source => source.PostVideos, opt => opt.DoNotValidate());
            CreateMap<Post, CreatePostModel>();
            CreateMap<CreatePostModel, Post>();
            CreateMap<Post, CreatePostModel>();
            CreateMap<Post, PostResponseModel>();
            CreateMap<PostResponseModel, Post>();
            CreateMap<User, RegistrationModel>();
            CreateMap<RegistrationModel, User>();
            CreateMap<FacebookModel, User>();
            CreateMap<User, FacebookModel>();
            CreateMap<CreateFriendModel, Friend>();
            CreateMap<DAL.Entities.Profile, ProfileModel>();
            CreateMap<CreateStoryModel, Story>();
        }
    }
}
