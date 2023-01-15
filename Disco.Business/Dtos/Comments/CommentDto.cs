using Disco.Business.Dtos.Chat;
using Disco.Business.Dtos.Images;
using Disco.Business.Dtos.Posts;
using Disco.Business.Dtos.Songs;
using Disco.Business.Dtos.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Dtos.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public AccountDto Account { get; set; }
    }
}
