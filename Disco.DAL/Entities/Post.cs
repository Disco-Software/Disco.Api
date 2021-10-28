using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Post : Base.BaseEntity<int>
    {
        public string Description { get; set; }

        public List<PostImage> PostImages { get; set; }
        public List<PostSong> PostSongs { get; set; }
        public List<PostVideo> PostVideos { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
