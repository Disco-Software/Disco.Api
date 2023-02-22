using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Interfaces.Dtos.Posts;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
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
            var post = await _postRepository.GetAsync(postId);

            post.Account.Posts.Remove(post);

            await _postRepository.Remove(post);
        }

        public async Task<List<Post>> GetAllUserPosts(User user,GetAllPostsDto dto)
        {
            return await Task.FromResult(_postRepository.GetUserPostsAsync(user.Id)
                .Result
                .OrderByDescending(post => post.DateOfCreation)
                .ToList());
        }

        public async Task<List<Post>> GetAllPostsAsync(User user, int pageNumber, int pageSize)
        {
            var posts = await _postRepository.GetUserPostsAsync(user.Account.Id);

            foreach (var follower in user.Account.Followers.AsEnumerable().ToList())
            {
                var followerPosts = await _postRepository.GetUserPostsAsync(follower.FollowerAccountId);

                posts.AddRange(followerPosts);
            }

            foreach (var following in user.Account.Following.AsEnumerable().ToList())
            {
                var followingPosts = await _postRepository.GetUserPostsAsync(following.FollowingAccountId);

                posts.AddRange(followingPosts);
            }


            return posts
                .OrderByDescending(p => p.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public async Task<List<Post>> GetAllPostsAsync(User user)
        {
            var posts = await _postRepository.GetUserPostsAsync(user.Id);

            foreach (var follower in user.Account.Followers)
            {
                var followerPosts = await _postRepository.GetUserPostsAsync(follower.FollowerAccountId);
                
                posts.AddRange(followerPosts);
            }

            foreach (var following in user.Account.Following)
            {
                var followingPosts = await _postRepository.GetUserPostsAsync(following.FollowerAccountId);

                posts.AddRange(followingPosts);
            }

            posts.OrderByDescending(p => p.DateOfCreation)
                .ToList();

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
            return await _postRepository.GetUserPostsAsync(user.Account.Id);
        }

    }
}
