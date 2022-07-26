
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class LikeService : ILikeSevice
    {
        private readonly PostRepository _postRepository;
        private readonly LikeRepository _likeRepository;

        public LikeService(
            PostRepository postRepository,
            LikeRepository likeRepository)
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
