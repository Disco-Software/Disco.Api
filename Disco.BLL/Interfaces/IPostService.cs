using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IPostService
    {
        Task<PostDTO> CreatePostAsync(PostModel post);
        Task<List<Post>> GetAllPostsAsync(Expression<Func<Post,bool>> expression);
        Task DeletePostAsync(int postId);
    }
}
