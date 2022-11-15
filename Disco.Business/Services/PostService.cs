using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Posts;
using Disco.Business.Dtos.Songs;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostService(
            IMapper mapper,
            IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task CreatePostAsync(Post post)
        {            
            post.DateOfCreation = DateTime.UtcNow;
            post.Account.Posts.Add(post);

            await _postRepository.AddAsync(post);
        }

        public async Task DeletePostAsync(int postId)
        {
            await _postRepository.Remove(postId);
        }

        public async Task<List<Post>> GetAllUserPosts(User user,GetAllPostsDto dto)
        {
            return await _postRepository.GetAllUserPosts(user.Id, dto.PageSize, dto.PageNumber);
        }

        public async Task<List<Post>> GetAllPosts(User user, GetAllPostsDto dto)
        {
            var posts = await _postRepository.GetAll(user.Id, dto.PageSize, dto.PageNumber);

            return posts;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _postRepository.GetAsync(id);
        }

        public async Task<List<Post>> GetPostsByDescriptionAsync(string search)
        {
            return await _postRepository.GetPostsByDescriptionAsync(search);
        }

        public async Task<List<Post>> GetAllUserPosts(User user)
        {
            return await _postRepository.GetUserPostsAsync(user.Id);
        }
    }
}
