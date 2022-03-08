using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Posts
{
    public class PostResponseModel
    {
        public Post Post { get; set; }
        public string VarificationResult { get; set; }
    }
}
