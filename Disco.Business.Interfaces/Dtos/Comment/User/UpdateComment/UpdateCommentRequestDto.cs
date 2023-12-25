using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Comment.User.UpdateComment
{
    public class UpdateCommentRequestDto
    {
        public UpdateCommentRequestDto(
            int commentId,
            string description)
        {
            CommentId = commentId;
            Description = description;
        }

        public int CommentId { get; set; }
        public string Description { get; set; }
    }
}
