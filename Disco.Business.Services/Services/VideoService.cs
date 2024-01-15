using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces.Dtos.PostVideo.User.CreatePostVideo;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Guards;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class VideoService : IVideoService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;
        private readonly IPostRepository _postRepository;


        public VideoService(
            BlobServiceClient blobServiceClient,
            IMapper mapper,
            IVideoRepository videoRepository,
            IPostRepository postRepository)
        {
            _videoRepository = videoRepository;
            _postRepository = postRepository;
            _blobServiceClient = blobServiceClient;
            _mapper = mapper;

            DefaultGuard.ArgumentNull(_videoRepository);
            DefaultGuard.ArgumentNull(_postRepository);
            DefaultGuard.ArgumentNull(_blobServiceClient);
            DefaultGuard.ArgumentNull(_mapper);
        }

        public async Task<PostVideo> CreateVideoAsync(CreatePostVideoRequestDto model)
        {
            var post = await _postRepository.GetAsync(model.PostId);
            var uniqueVideoName = Guid.NewGuid().ToString() + "_" + model.VideoFile.FileName.Replace(' ', '_');

            if (model.VideoFile == null)
                return null;

            if (model.VideoFile.Length == 0)
                return null;

            var containerClient = _blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = containerClient.GetBlobClient(uniqueVideoName);

            using var videoReader = model.VideoFile.OpenReadStream();
            var blobResult = blobClient.Upload(videoReader);

            var video = _mapper.Map<PostVideo>(model);
            video.VideoSource = blobClient.Uri.AbsoluteUri;

            await _videoRepository.AddAsync(video);

            return video;
        }

        public async Task RemoveVideoAsync(int id)
        {
            var video = await _videoRepository.GetAsync(id);

            video.Post.PostVideos.Remove(video);

            await _videoRepository.RemoveAsync(video);
        }
    }
}
