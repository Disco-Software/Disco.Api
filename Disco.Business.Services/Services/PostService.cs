﻿using AutoMapper;
using Disco.Business.Interfaces.Dtos.Posts;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Guards;
using Disco.Domain.Events.Events;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Integration.Interfaces.Interfaces;
using Disco_Business_Services;

namespace Disco.Business.Services.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepository _postRepository;
        private readonly IRecommendationServiceBusPublisher _eventPublisher;
        private readonly IMapper _mapper;
        public PostService(
            IMapper mapper,
            IRecommendationServiceBusPublisher eventPublisher,
            IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _eventPublisher = eventPublisher;   
            _mapper = mapper;

            DefaultGuard.ArgumentNull(_postRepository);
            DefaultGuard.ArgumentNull(_mapper);
            DefaultGuard.ArgumentNull(_eventPublisher);
        }

        public async Task CreatePostAsync(Post post)
        {            
            post.DateOfCreation = DateTime.UtcNow;
            post.Account.Posts.Add(post);

            await _postRepository.AddAsync(post);

            var postEvent = _mapper.Map<PostCreatedEvent>(post);

            await _eventPublisher.PublishAsync(postEvent);
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await _postRepository.GetAsync(postId);

            await _postRepository.RemoveAsync(post);
        }

        public async Task<List<Post>> GetAllUserPosts(User user,GetAllPostsDto dto)
        {
            return await _postRepository.GetUserPostsAsync(user.AccountId, dto.PageNumber, dto.PageSize);
        }

        public async Task<List<Post>> GetAllPostsAsync(User user, int pageNumber, int pageSize)
        {
            var posts = await _postRepository.GetUserPostsAsync(user.Account.Id);
            var recommendedPosts = await _postRepository.GetAllPostsAsync();

            foreach (var following in user.Account.Following.AsEnumerable().ToList())
            {
                var followingPosts = await _postRepository.GetUserPostsAsync(following.FollowingAccountId, pageNumber, pageSize);

                posts.AddRange(followingPosts);
            }

            foreach (var post in recommendedPosts)
            {
                foreach (var postReating in post.PostReating)
                {
                    var output = PostModel.Predict(new PostModel.ModelInput
                    {
                        Col0 = postReating.Id,
                        Col3 = post.Id,
                        Col4 = post.AccountId,
                    });

                    var outputPost = await _postRepository.GetAsync(int.Parse(output.Col3.ToString()));

                    posts.Add(outputPost);
                }
            }

            return posts
                .OrderByDescending(p => p.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public async Task<List<Post>> GetAllPostsAsync(User user)
        {
            var posts = await _postRepository.GetUserPostsAsync(user.AccountId);

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

            posts
                .OrderByDescending(p => p.DateOfCreation)
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

        public int GetPostsCount(int accountId)
        {
            var postsCount = _postRepository.GetPostsCount(accountId);

            return postsCount;
        }
    }
}
