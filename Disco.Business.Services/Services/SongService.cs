using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Business.Interfaces.Dtos.PostSong.User.CreatePostSong;

namespace Disco.Business.Services.Services
{
    public class SongService : ISongService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;
        private readonly IPostRepository _postRepository;

        public SongService(
            BlobServiceClient blobServiceClient,
            IMapper mapper,
            ISongRepository songRepository,
            IPostRepository postRepository)
        {
            _songRepository = songRepository;
            _postRepository = postRepository;
            _blobServiceClient = blobServiceClient;
            _mapper = mapper;
        }

        public async Task<PostSong> CreatePostSongAsync(CreatePostSongRequestDto dto)
        {            
            var uniqueSongName = Guid.NewGuid().ToString() + "_" + dto.Song.FileName.Replace(' ', '_');
            var uniqueImageName = Guid.NewGuid().ToString() + "_" + dto.Image.FileName.Replace(' ', '_');
           
            if (dto.Song == null)
                return null;

            if (dto.Song.Length == 0)
                return null;

            var blobSongContainerClient = _blobServiceClient.GetBlobContainerClient("songs");
            var blobImageContainerClient = _blobServiceClient.GetBlobContainerClient("images");
           
            var blobSongClient = blobSongContainerClient.GetBlobClient(uniqueSongName);
            var blobImageClient = blobImageContainerClient.GetBlobClient(uniqueImageName);

            using var songReader = dto.Song.OpenReadStream();
            var blobSongResult = blobSongClient.Upload(songReader);

            using var imageReader = dto.Image.OpenReadStream();
            var blobImageResult = blobImageClient.Upload(imageReader);

            var song = _mapper.Map<PostSong>(dto);
            song.ImageUrl = blobImageClient.Uri.AbsoluteUri;
            song.Source = blobSongClient.Uri.AbsoluteUri;
            song.Name = dto.Name;

            await _songRepository.AddAsync(song);

            return song;
        }

        public async Task RemoveAsync(int songId)
        {
            var postSong = await _songRepository.GetAsync(songId);

            postSong.Post.PostSongs.Remove(postSong);

            await _songRepository.RemoveAsync(postSong);
        }
    }
}
