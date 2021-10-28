using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class PostSong : Base.BaseEntity<int>
    {
        public string ImageUrl { get; set; }
        public string Source { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
