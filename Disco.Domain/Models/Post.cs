using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disco.Domain.Models
{
    public class Post : Base.BaseModel<int>
    {
        public string Description { get; set; }

        public List<PostImage> PostImages { get; set; } = new List<PostImage>();
        public List<PostSong> PostSongs { get; set; } = new List<PostSong>();
        public List<PostVideo> PostVideos { get; set; } = new List<PostVideo>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

        [Column(TypeName = "date")]
        public DateTime? DateOfCreation { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
