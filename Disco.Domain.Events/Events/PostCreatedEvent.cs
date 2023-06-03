using Disco.Domain.Events.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Events.Events
{
    public class PostCreatedEvent
    {
        public string Description { get; set; }

        public List<PostImageDto> PostImages { get; set; }
        public List<PostSongDto> PostSongs { get; set; }
        public List<PostSongDto> PostVideos { get; set; }
        public List<LikeDto> Likes { get; set; }
        public DateTime? DateOfCreation { get; set; }
        
        public AccountDto Account { get; set; }
    }
}
