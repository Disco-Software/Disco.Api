using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface ICommentService
    {
        Task AddCommentAsync(Comment comment);
        Task RemoveCommentAsync(Comment comment);
        Task<Comment> GetCommentAsync(int id);
    }
}
