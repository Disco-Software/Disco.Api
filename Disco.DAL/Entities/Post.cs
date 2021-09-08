using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Post : Base.BaseEntity<int>
    {
        public string Description { get; set; }
        
        [ForeignKey("Song")]
        public int? SongId { get; set; }
        public Song Song { get; set; }
        
        [ForeignKey("Video")]
        public int? VideoId { get; set; }
        public Video VideoSource { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
