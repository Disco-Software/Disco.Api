using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.DTO
{
    public class PostDTO
    {
        public Post Post { get; set; }
        public string VarificationResult { get; set; }
    }
}
