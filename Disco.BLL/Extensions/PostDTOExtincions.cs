using Disco.BLL.DTO;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Extensions
{
    public abstract class PostDTOExtincions
    {
        public static PostDTO Ok(Post post) => new PostDTO { Post = post };

        public static PostDTO Ok(Post post, string varificationResult) => new PostDTO { Post = post, VarificationResult = varificationResult };

        public static PostDTO BedRequest(string varificationResult) => new PostDTO { VarificationResult = varificationResult };
    }
}
