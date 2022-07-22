﻿namespace Disco.Domain.Models
{
    public class PostImage : Base.BaseEntity<int>
    {
        public string Source { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}