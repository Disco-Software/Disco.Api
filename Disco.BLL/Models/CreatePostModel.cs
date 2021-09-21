using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models
{
    public class CreatePostModel
    {
        public string Description { get; set; }
        public Nullable<int> SongId { get; set; }
        public Nullable<int> ImageId { get; set; }
        public Nullable<int> VideoId { get; set; }
        public string Email { get; set; }
    }
}
