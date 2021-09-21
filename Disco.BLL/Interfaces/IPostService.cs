using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IPostService
    {
        Task<PostDTO> CreatePostAsync(CreatePostModel model);
        Task<List<Post>> GetAllUserPosts(Expression<Func<Post,bool>> expression);
        Task DeletePostAsync(int postId);
    }
}
