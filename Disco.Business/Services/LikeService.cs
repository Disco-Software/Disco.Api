
using Disco.Business.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class LikeService : ILikeService
    {
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;

        public LikeService(
            IPostRepository postRepository,
            ILikeRepository likeRepository)
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
        }

        public async Task<List<Like>> CreateLikeAsync(User user, int postId)
        {
            var post = await _postRepository.Get(postId);
           
            var like = new Like
            {
                Post = post,
                UserName = user.UserName,
                PostId = postId,
            };

            await _likeRepository.AddAsync(like, postId);

            return post.Likes;
        }

        public async Task<List<Like>> RemoveLikeAsync(User user, int postId)
        {
            var post = await _postRepository.Get(postId);
            
            var like = post.Likes
                .Where(u => u.UserName == user.UserName)
                .FirstOrDefault();

           await _likeRepository.Remove(like.Id);

            return post.Likes;
        }
    }
}
