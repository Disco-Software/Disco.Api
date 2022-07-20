using AutoMapper;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dto.Posts
{
    public class CreatePostDto
    {
        public string Description { get; set; }
        public List<IFormFile> PostImages { get; set; }
        public List<IFormFile> PostSongs { get; set; }
        public List<IFormFile> PostSongImages { get; set; }
        public List<string> PostSongNames { get; set; }
        public List<string> ExecutorNames { get; set; }
        public List<IFormFile> PostVideos { get; set; }
    }
}
