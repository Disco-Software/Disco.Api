using AutoMapper;
using Disco.Business.Interfaces.Dtos.Stories;
using Disco.Business.Interfaces.Dtos.StoryImages;
using Disco.Business.Interfaces.Dtos.StoryVideos;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Services.Mappers
{
    public class StoryMapProfile : Profile
    {
        public StoryMapProfile()
        {
            CreateMap<CreateStoryDto, Story>()
                .ForMember(source => source.StoryImages, opt => opt.Ignore())
                .ForMember(source => source.StoryVideos, opt => opt.Ignore())
                .ForMember(source => source.DateOfCreation, opt => opt.Ignore());
            
            CreateMap<CreateStoryImageDto, StoryImage>()
                .ForMember(source => source.Source, opt => opt.Ignore());
            
            CreateMap<CreateStoryVideoDto, StoryVideo>()
                .ForMember(source => source.Source, opt => opt.Ignore());
        }
    }
}
