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
        private readonly Lazy<SongRepository> songRepository;
        private readonly Lazy<VideoRepository> videoRepository;

        public RepositoryManager(ApiDbContext _ctx)
        {
            postRepository = new Lazy<PostRepository>(() => new PostRepository(_ctx));
            songRepository = new Lazy<SongRepository>(() => new SongRepository(_ctx));
            videoRepository = new Lazy<VideoRepository>(() => new VideoRepository(_ctx));
        }

        public PostRepository PostRepository => postRepository.Value;

        public SongRepository SongRepository => songRepository.Value;

        public VideoRepository VideoRepository => videoRepository.Value;
    }
}
