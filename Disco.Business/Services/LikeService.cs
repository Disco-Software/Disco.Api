
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

        public async Task<List<Like>> ToggleLikeAsync(User user, int postId)
        {
            var post = await _postRepository.Get(postId);
            var like = await _likeRepository.GetAsync(user.UserName);

            if(like == null)
            {
                like = new Like
                {
                    UserName = user.UserName,
                    Post = post,
                    PostId = postId,
                };

                await _likeRepository.AddAsync(like, postId);
            }
            else if (like != null)
            {
                await _likeRepository.Remove(like.Id);

                return post.Likes;
            }
            
            return post.Likes;
        }
    }
}
