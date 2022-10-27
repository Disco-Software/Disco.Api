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
        private readonly IAccountService _userService;
        private readonly IPostRepository _postRepository;
        private readonly IImageService _imageService;
        private readonly ISongService _songService;
        private readonly IVideoService _videoService;
        private readonly ILikeService _likeService;
        private readonly IMapper _mapper;
        public PostService(
            IAccountService userService,
            IMapper mapper,
            IPostRepository postRepository,
            IImageService imageService,
            ISongService songService,
            IVideoService videoService,
            ILikeService likeService)
        {
            _postRepository = postRepository;
            _userService = userService;
            _mapper = mapper;
            _imageService = imageService;
            _songService = songService;
            _videoService = videoService;
            _likeService = likeService;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {            
            post.DateOfCreation = DateTime.UtcNow;

            await _postRepository.AddAsync(post);

            return post;
        }

        public async Task DeletePostAsync(int postId)
        {
            await _postRepository.Remove(postId);
        }

        public async Task<List<Post>> GetAllUserPosts(User user,GetAllPostsDto model)
        {
            return await _postRepository.GetAllUserPosts(user.Id, model.PageSize, model.PageNumber);
        }

        public async Task<List<Post>> GetAllPosts(User user, GetAllPostsDto model)
        {
            var posts = await _postRepository.GetAll(user.Id, model.PageSize, model.PageNumber);

            for(int i = 0; i < posts.Count; i++)
            {
                var post = posts[i];
                post.Likes = await _likeService.GetAllLikesAsync(post.Id);
            }

            return posts;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _postRepository.GetAsync(id);
        }

        public async Task<List<Post>> SearchPostsAsync(string search)
        {
            return await _postRepository.GetPostsByDescriptionAsync(search);
        }
    }
}
