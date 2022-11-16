
using AutoMapper;
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
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public LikeService(
            ILikeRepository likeRepository,
            IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<List<Like>> AddLikeAsync(User user, Post post)
        {
            var like = await _likeRepository.GetAsync(post.Id);

            if (like != null)
            {
                return null;
            }

            like = _mapper.Map<Like>(post);
            like.Post = post;
            like.PostId = post.Id;
            like.Account = user.Account;

            if(post.Likes.All(p => p.Account.User.UserName != user.UserName))
            {
                post.Likes.Add(like);
            }

            await _likeRepository.AddAsync(like);

            return post.Likes;
        }

        public async Task<List<Like>> GetAllLikesAsync(int postId)
        {
           return await _likeRepository.GetAll(postId);
        }

        public async Task<List<Like>> RemoveLikeAsync(User user, Post post)
        {
            var like = await _likeRepository.GetAsync(post.Id);

            if (like == null)
                throw new System.Exception("Error");

            await _likeRepository.Remove(like, post.Id);

            return post.Likes;
        }

        public async Task<List<Like>> GetAllLikesAsync(int postId, int pageNumber, int pageSize)
        {
            return await _likeRepository.GetAll(postId);
        }
    }
}
