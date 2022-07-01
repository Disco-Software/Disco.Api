using System;
using System.Collections.Generic;

namespace Disco.Tests.Models
{
    public class Post
    {
        public List<PostImage> PostImages { get; set; } = new List<PostImage>();
        public List<PostSong> PostSongs { get; set; } = new List<PostSong>();
        public List<PostVideo> PostVideos { get; set; } = new List<PostVideo>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public DateTime? DateOfCreation { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

    }
}