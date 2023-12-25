using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Comment.User.DeleteComment
{
    public class DeleteCommentRequestDto
    {
        public DeleteCommentRequestDto(
            int postId, 
            int commentId)
        {
            PostId = postId;
            CommentId = commentId;
        }

        public int PostId { get; set; }
        public int CommentId { get; set; }
    }
}
