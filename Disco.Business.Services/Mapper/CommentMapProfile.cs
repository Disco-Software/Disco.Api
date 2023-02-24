using AutoMapper;
using Disco.Business.Interfaces.Dtos.Comments;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Mappers
{
    public class CommentMapProfile : Profile
    {
        public CommentMapProfile()
        {
            CreateMap<Post, Comment>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.PostId, options => options.MapFrom(post => post.Id))
                .ForMember(c => c.AccountId, options => options.MapFrom(post => post.AccountId))
                .ForMember(c => c.Account, options => options.MapFrom(post => post.Account))
                .ForMember(c => c.Post, options => options.MapFrom(post => post));

            CreateMap<Comment, CommentDto>()
                .ForMember(c => c.Id, options => options.MapFrom(comment => comment.Id))
                .ForMember(c => c.Description, options => options.MapFrom(comment => comment.CommentDescription))
                .ForMember(c => c.Account, options => options.Ignore());
        }
    }
}
