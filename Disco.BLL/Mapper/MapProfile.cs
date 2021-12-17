using AutoMapper;
using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.BLL.Models.Facebook;
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
            CreateMap<CreatePostModel, Post>();
            CreateMap<Post, CreatePostModel>();
            CreateMap<CreatePostModel, Post>();
            CreateMap<Post, CreatePostModel>();
            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();
            CreateMap<User, RegistrationModel>();
            CreateMap<RegistrationModel, User>();
            CreateMap<FacebookModel, User>();
            CreateMap<User, FacebookModel>();
        }
    }
}
