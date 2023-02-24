using Disco.Business.Interfaces.Dtos.Chat;
using Disco.Business.Interfaces.Dtos.Images;
using Disco.Business.Interfaces.Dtos.Posts;
using Disco.Business.Interfaces.Dtos.Songs;
using Disco.Business.Interfaces.Dtos.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public AccountDto Account { get; set; }
    }
}
