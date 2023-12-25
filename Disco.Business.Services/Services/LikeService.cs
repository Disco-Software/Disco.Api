
using AutoMapper;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
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

        public async Task CreateLikeAsync(Like like)
        {
            like.Post.Likes.Add(like);

            await _likeRepository.AddAsync(like);
        }

        public async Task<List<Like>> GetAllLikesAsync(int postId, int pageNumber, int pageSize)
        {
            return await _likeRepository.GetAllAsync(postId, pageNumber, pageSize);
        }

        public async Task DeleteLikeAsync(Like like)
        {
            like.Post.Likes.Remove(like);

            await _likeRepository.RemoveAsync(like);
        }

        public async Task<Like> GetAsync(int accountId, int postId)
        {
            return await _likeRepository.GetAsync(accountId, postId);
        }
    }
}
