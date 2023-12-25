using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Comment.User.CreateComment
{
    public class CreateCommentResponseDto
    {
        public CreateCommentResponseDto() { }
        public CreateCommentResponseDto(
            int id,
            string description,
            DateTime createdDate,
            AccountDto author,
            PostDto post)
        {
            Id = id;
            Description = description;
            CreatedDate = createdDate;
            Author = author;
            Post = post;
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public AccountDto Author { get; set; }
        public PostDto Post { get; set; }
    }
}
