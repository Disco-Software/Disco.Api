using Disco.BLL.DTO;
using Disco.BLL.Models.Posts;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Extensions
{
    public abstract class PostApiRequestHandlerBase
    {
        public static PostResponseModel Ok(Post post) => new PostResponseModel { Post = post };

        public static PostResponseModel Ok(Post post, string varificationResult) => new PostResponseModel { Post = post, VarificationResult = varificationResult };

        public static PostResponseModel BedRequest(string varificationResult) => new PostResponseModel { VarificationResult = varificationResult };
    }
}
