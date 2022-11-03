using AutoMapper;
using Disco.Business.Dtos.AudD;
using Disco.Business.Dtos.Images;
using Disco.Business.Dtos.Posts;
using Disco.Business.Dtos.Songs;
using Disco.Business.Dtos.Videos;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Mapper
{
    public class PostMapProfile : Profile
    {
        public PostMapProfile()
        {
            CreateMap<CreatePostDto, Post>()
                .ForMember(source => source.PostImages, opt => opt.Ignore())
                .ForMember(source => source.PostSongs, opt => opt.Ignore())
                .ForMember(source => source.PostVideos, opt => opt.Ignore());
            
            CreateMap<CreatePostDto, CreateImageDto>()
                .ForMember(source => source.ImageFile, opt => opt.Ignore());
            
            CreateMap<CreatePostDto, CreateSongDto>()
                .ForMember(source => source.Post, opt => opt.Ignore())
                .ForMember(source => source.Name, opt => opt.Ignore())
                .ForMember(source => source.Image, opt => opt.Ignore())
                .ForMember(source => source.ExecutorName, opt => opt.Ignore());
            
            CreateMap<CreateVideoDto, PostVideo>()
                .ForMember(source => source.VideoSource, opt => opt.Ignore())
                .ForMember(source => source.Post, opt => opt.Ignore())
                .ForMember(source => source.PostId, opt => opt.Ignore());

            CreateMap<CreateImageDto, PostImage>()
                .ForMember(source => source.Source, opt => opt.Ignore())
                .ForMember(source => source.Post, opt => opt.Ignore())
                .ForMember(source => source.PostId, opt => opt.Ignore())
                .ForMember(source => source.Id, opt => opt.Ignore());
            
            CreateMap<CreateSongDto, PostSong>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            
            CreateMap<CreateVideoDto, PostVideo>()
                .ForMember(source => source.VideoSource, opt => opt.Ignore());

            CreateMap<Post, Like>()
                .ForMember(p => p.PostId, opt => opt.Ignore())
                .ForMember(p => p.Post, opt => opt.Ignore())
                .ForMember(p => p.UserName, opt => opt.Ignore());

            CreateMap<PostSong, AudDRequestDto>()
                .ForMember(p => p.@return, o => o.Ignore())
                .ForMember(p => p.api_token, o => o.Ignore())
                .ForMember(p => p.url, o => o.Ignore());    
        }
    }
}
