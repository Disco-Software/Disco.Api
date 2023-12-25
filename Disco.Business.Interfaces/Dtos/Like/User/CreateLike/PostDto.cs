using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Like.User.CreateLike
{
    public class PostDto
    {
        public PostDto() { }
        public PostDto(
            int postId)
        {
            PostId = postId;
        }

        public int PostId {  get; set; }
    }
}
