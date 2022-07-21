using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dto.Videos;
using Disco.Domain.Models;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class VideoService : IVideoService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;
        private readonly IVideoRepository videoRepository;
        private readonly IPostRepository postRepository;


        public VideoService(
            BlobServiceClient _blobServiceClient,
            IMapper _mapper,
            IVideoRepository _videoRepository,
            IPostRepository _postRepository)
        {
            videoRepository = _videoRepository;
            postRepository = _postRepository;
            blobServiceClient = _blobServiceClient;
            mapper = _mapper;
        }

        public async Task<PostVideo> CreateVideoAsync(CreateVideoDto model)
        {
            var post = await postRepository.Get(model.PostId);
            var uniqueVideoName = Guid.NewGuid().ToString() + "_" + model.VideoFile.FileName.Replace(' ', '_');

            if (model.VideoFile == null)
                return null;

            if (model.VideoFile.Length == 0)
                return null;

            var containerClient = blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = containerClient.GetBlobClient(uniqueVideoName);

            using var videoReader = model.VideoFile.OpenReadStream();
            var blobResult = blobClient.Upload(videoReader);

            var video = mapper.Map<PostVideo>(model);
            video.VideoSource = blobClient.Uri.AbsoluteUri;

            await videoRepository.AddAsync(video);

            return video;
        }

        public async Task RemoveVideoAsync(int id)
        {
            await videoRepository.Remove(id);
        }
    }
}
