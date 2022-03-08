using AutoMapper;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Posts
{
    public class CreatePostModel
    {
        public string Description { get; set; }
        public List<IFormFile> PostImages { get; set; }
        public List<IFormFile> PostSongs { get; set; }
        public List<IFormFile> PostVideos { get;set; }
        public string Name { get; set; }
    }
}
