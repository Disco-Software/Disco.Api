using Disco.Business.Interfaces.Attributes;
using Disco.Business.Interfaces.Validators;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Disco.Business.Interfaces.Dtos.Posts
{
    [ValidationType(typeof(CreatePostValidator))]
    public class CreatePostDto
    {
        public string Description { get; set; }
        public List<IFormFile>? PostImages { get; set; }
        public List<IFormFile>? PostSongs { get; set; }
        public List<IFormFile>? PostSongImages { get; set; }
        public List<string>? PostSongNames { get; set; }
        public List<string>? ExecutorNames { get; set; }
        public List<IFormFile>? PostVideos { get; set; }
    }
}
