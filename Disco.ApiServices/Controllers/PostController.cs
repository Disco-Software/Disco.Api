using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Posts;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using Disco.Business.Dtos.Songs;
using Disco.Business.Dtos.Images;
using Disco.Business.Dtos.Videos;
using Microsoft.Extensions.Options;
using Disco.Business.Options;
using Disco.Business.Dtos.AudD;
using Disco.Business.Services;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
    [Route("api/user/posts")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IImageService _imageService;
        private readonly ISongService _songService;
        private readonly IVideoService _videoService;
        private readonly ILikeService _likeService;
        private readonly IFollowerService _followerService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public PostController(
            IPostService postService,
            IImageService imageService,
            ISongService songService,
            IVideoService videoService,
            ILikeService likeService,
            IFollowerService followerService,
            IAccountService accountService,
            IMapper mapper)
        {
            _postService = postService;
            _imageService = imageService;
            _songService = songService;
            _videoService = videoService;
            _accountService = accountService;
            _likeService = likeService;
            _followerService = followerService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreatePostDto dto)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var post = _mapper.Map<Post>(dto);
            post.Account = user.Account;
            post.AccountId = user.AccountId;
            post.Description = dto.Description;
            post.DateOfCreation = System.DateTime.UtcNow;

            if(dto.PostImages != null)
            {
                foreach (var image in dto.PostImages.ToList())
                {
                    var postImageDto = _mapper.Map<CreateImageDto>(dto);
                    postImageDto.ImageFile = image;

                    var postImage = await _imageService.CreatePostImage(postImageDto);
                    postImage.Post = post;
                    postImage.PostId = post.Id;

                    post.PostImages.Add(postImage);

                    dto.PostImages.Remove(image);
                }
            }
            if(dto.PostSongs != null)
            {
                foreach (var song in dto.PostSongs.ToList())
                {
                    var name = dto.PostSongNames.First();
                    var artist = dto.ExecutorNames.First();
                    var songSource = dto.PostSongs.First();
                    var songImage = dto.PostSongImages.First();

                    var postSongDto = _mapper.Map<CreateSongDto>(dto);
                    postSongDto.Name = name;
                    postSongDto.ExecutorName = artist;
                    postSongDto.Post = post;
                    postSongDto.Image = songImage;
                    postSongDto.Song = songSource;

                    var postSong = await _songService.CreatePostSongAsync(postSongDto);

                    dto.PostSongNames.Remove(name);
                    dto.ExecutorNames.Remove(artist);
                    dto.PostSongs.Remove(songSource);
                    dto.PostSongImages.Remove(songImage);
                }
            }

            if(dto.PostVideos != null)
            {
                foreach (var video in dto.PostVideos.ToList())
                {
                    var postVideoDto = _mapper.Map<CreateVideoDto>(dto);
                    postVideoDto.VideoFile = video;

                    var postVideo = await _videoService.CreateVideoAsync(postVideoDto);

                    dto.PostImages.Remove(video);
                }
            }

             await _postService.CreatePostAsync(post);

            return Ok(post);
        }

        [HttpDelete("{postId:int}")]
        public async Task Delete([FromRoute] int postId)
        {
            await _postService.DeletePostAsync(postId);
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllUserPosts([FromQuery] GetAllPostsDto dto)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            return await _postService.GetAllUserPosts(user, dto);
        }

        [HttpGet("line")]
        public async Task<ActionResult<List<Post>>> GetAllPosts([FromQuery] GetAllPostsDto dto)
        {
            var user = await _accountService.GetAsync(HttpContext.User);
            
            user.Account.Following = await _followerService.GetFollowingAsync(user.Id);
            user.Account.Followers = await _followerService.GetFollowersAsync(user.Id);

            var posts = await _postService.GetAllPostsAsync(user);

            for (int i = 0; i < posts.Count; i++)
            {
                var post = posts[i];
                post.Likes = await _likeService.GetAllLikesAsync(post.Id);
            }

            return posts;
        }
    }
}
