using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Guards;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;

            DefaultGuard.ArgumentNull(_commentRepository);
        }

        public async Task AddCommentAsync(Comment comment)
        {
            comment.Post.Comments.Add(comment);
            comment.Account.Comments.Add(comment);

            await _commentRepository.AddAsync(comment);
        }

        public async Task RemoveCommentAsync(Comment comment)
        {
            comment.Post.Comments.Remove(comment);
            comment.Account.Comments.Remove(comment);

            await _commentRepository.RemoveAsync(comment);
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            return await _commentRepository.GetAsync(id);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            await _commentRepository.UpdateAsync(comment);
        }

        public async Task<List<Comment>> GetAllCommentsAsync(int postId, int pageNumber, int pageSize)
        {
            return await _commentRepository.GetAllAsync(postId, pageNumber, pageSize);
        }
    }
}
