using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Comment.User.UpdateComment
{
    public class UpdateCommentResponseDto
    {
        public UpdateCommentResponseDto() { }
        public UpdateCommentResponseDto(
            int id, 
            string description, 
            DateTime createdDate, 
            PostDto post, 
            AccountDto account)
        {
            Id = id;
            Description = description;
            CreatedDate = createdDate;
            Post = post;
            Account = account;
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public PostDto Post { get; set; }
        public AccountDto Account { get; set; }
    }
}
