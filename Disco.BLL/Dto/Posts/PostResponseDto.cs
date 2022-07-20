using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dto.Posts
{
    public class PostResponseDto
    {
        public Post Post { get; set; }
        public string VarificationResult { get; set; }
    }
}
