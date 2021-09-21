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


        public Nullable<int> ImageId { get; set; }
        public PostImage PostImage { get; set; }

        public Nullable<int> SongId { get; set; }
        public PostSong Song { get; set; }

        public Nullable<int> VideoId { get; set; }
        public PostVideo Video { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
