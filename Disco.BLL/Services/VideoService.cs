using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Videos;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class VideoService : IVideoService
    {
        private readonly VideoRepository videoRepository;
        private readonly PostRepository postRepository;
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;

        public VideoService(
            VideoRepository _videoRepository,
            PostRepository _postRepository,
            BlobServiceClient _blobServiceClient,
            IMapper _mapper)
        {
            videoRepository = _videoRepository;
            postRepository = _postRepository;
            blobServiceClient = _blobServiceClient;
            mapper = _mapper;
        }

        public async Task<PostVideo> CreateVideoAsync(CreateVideoModel model)
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

            await videoRepository.Add(video);

            return video;
        }

        public async Task RemoveVideoAsync(int id)
        {
            await videoRepository.Remove(id);
        }
    }
}
