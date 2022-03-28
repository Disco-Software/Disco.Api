using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Story : Base.BaseEntity<int>
    {
        public List<StoryImage> StoryImages { get; set; }
        public List<StoryVideo> StoryVideos { get; set;}

        [Column(TypeName = "date")]
        public DateTime DateOfCreation { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
