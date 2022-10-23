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

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [Route("api/user/posts")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IImageService _imageService;
        private readonly ISongService _songService;
        private readonly IVideoService _videoService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public PostController(
            IPostService postService,
            IImageService imageService,
            ISongService songService,
            IVideoService videoService,
            IAccountService accountService,
            IMapper mapper)
        {
            _postService = postService;
            _songService = songService;
            _imageService = imageService;
            _songService = songService;
            _videoService = videoService;
            _accountService = accountService;
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
                    var executor = dto.ExecutorNames.First();
                    var songSource = dto.PostSongs.First();
                    var songImage = dto.PostSongImages.First();

                    var postSongDto = _mapper.Map<CreateSongDto>(dto);
                    postSongDto.Name = name;
                    postSongDto.ExecutorName = executor;
                    postSongDto.Post = post;
                    postSongDto.Image = songImage;
                    postSongDto.Song = songSource;

                    var postSong = await _songService.CreatePostSongAsync(postSongDto);

                    dto.PostSongNames.Remove(name);
                    dto.ExecutorNames.Remove(executor);
                    dto.PostSongs.Remove(songSource);
                    dto.PostSongImages.Remove(songImage);

                    post.PostSongs.Add(postSong);
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

            post = await _postService.CreatePostAsync(post);

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

            var posts = await _postService.GetAllPosts(user, dto);

            return posts;
        }
    }
}
