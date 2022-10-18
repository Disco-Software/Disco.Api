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

        public async Task<Post> CreatePostAsync(User user, CreatePostDto model)
        {            
            var post = _mapper.Map<Post>(model);
            post.Account = user.Account;
            post.AccountId = user.Account.Id;
            
            if (model.PostImages != null)
                foreach (var file in model.PostImages)
                {
                    var image = await _imageService.CreatePostImage(
                        new Dtos.Images.CreateImageDto { ImageFile = file });
                    post.PostImages.Add(image);
                }
            if (model.PostSongs != null)
                foreach (var postSong in model.PostSongs)
                {
                    var name = model.PostSongNames.First();
                    var image = model.PostSongImages.First();
                    var executorName = model.ExecutorNames.First();

                    var song = await _songService.CreatePostSongAsync(
                         new CreateSongDto { SongFile = postSong, SongImage = image, Name = name, ExecutorName = executorName, PostId = post.Id });
                   
                    model.PostSongNames.Remove(name);
                    model.PostSongImages.Remove(image);
                    model.ExecutorNames.Remove(executorName);

                    post.PostSongs.Add(song);
                }
            if (model.PostVideos != null)
                foreach (var video in model.PostVideos)
                {
                    var postVideo = await _videoService.CreateVideoAsync(
                        new Dtos.Videos.CreateVideoDto { VideoFile = video });
                    post.PostVideos.Add(postVideo);
                }

            post.AccountId = user.Account.Id;
            post.Account = user.Account;
            post.DateOfCreation = DateTime.UtcNow;

            await _postRepository.AddAsync(post,user);

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
            var posts = await _postRepository.GetAllPosts(user.Id, model.PageSize, model.PageNumber);

            for(int i = 0; i < posts.Count; i++)
            {
                var post = posts[i];
                post.Likes = await _likeService.GetAllLikesAsync(post.Id);
            }

            return posts;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _postRepository.Get(id);
        }

        public async Task<List<Post>> SearchPostsAsync(string search)
        {
            return await _postRepository.GetPostsByDescriptionAsync(search);
        }
    }
}
