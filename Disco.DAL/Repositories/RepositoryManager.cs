using Disco.DAL.EF;
using Disco.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<PostRepository> postRepository;
        private readonly Lazy<ImageRepository> imageRepository;
        private readonly Lazy<SongRepository> songRepository;
        private readonly Lazy<VideoRepository> videoRepository;
        private readonly Lazy<FriendRepository> friendRepository;
        private readonly Lazy<ProfileRepository> profileRepository;
        private readonly Lazy<StoryRepository> storyRepository;
        private readonly Lazy<StoryImageRepository> storyImageRepository;
        private readonly Lazy<StoryVideoRepository> storyVideoRepository;
        private readonly Lazy<LikeRepository> likeRepository;
        private readonly Lazy<UserRepository> userRepository;
        public RepositoryManager(ApiDbContext _ctx)
        {
            postRepository = new Lazy<PostRepository>(() => new PostRepository(_ctx));
            songRepository = new Lazy<SongRepository>(() => new SongRepository(_ctx));
            videoRepository = new Lazy<VideoRepository>(() => new VideoRepository(_ctx));
            profileRepository = new Lazy<ProfileRepository>(() => new ProfileRepository(_ctx));
            friendRepository = new Lazy<FriendRepository>(() => new FriendRepository(_ctx));
            storyRepository = new Lazy<StoryRepository>(() => new StoryRepository(_ctx));
            imageRepository = new Lazy<ImageRepository>(() => new ImageRepository(_ctx));
            storyImageRepository = new Lazy<StoryImageRepository>(() => new StoryImageRepository(_ctx));
            storyVideoRepository = new Lazy<StoryVideoRepository>(() => new StoryVideoRepository(_ctx));
            likeRepository = new Lazy<LikeRepository>(() => new LikeRepository(_ctx));
            userRepository = new Lazy<UserRepository>(() => new UserRepository(_ctx));
        }

        public PostRepository PostRepository => postRepository.Value;

        public SongRepository SongRepository => songRepository.Value;

        public VideoRepository VideoRepository => videoRepository.Value;

        public FriendRepository FriendRepository => friendRepository.Value;

        public  ProfileRepository ProfileRepository => profileRepository.Value;

        public StoryRepository StoryRepository => storyRepository.Value;

        public ImageRepository ImageRepository => imageRepository.Value;

        public StoryImageRepository StoryImageRepository => storyImageRepository.Value;

        public StoryVideoRepository StoryVideoRepository => storyVideoRepository.Value;

        public LikeRepository LikeRepository => likeRepository.Value;

        public UserRepository UserRepository => userRepository.Value;
    }
}
