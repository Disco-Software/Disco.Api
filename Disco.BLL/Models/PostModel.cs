using Disco.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models
{
    public class PostModel
    {
        public string Description { get; set; }
        public string VideoSource { get; set; } = "";
        public IFormFile VideoFile { get; set; }
        public string ImageUrl { get; set; } = "";
        public IFormFile ImageFile { get; set; }
        public string AudioSource { get; set; } = "";
        public IFormFile AudioFile { get; set; }
        public int UserId { get; set; }
    }
}
