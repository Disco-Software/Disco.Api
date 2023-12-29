using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public class EmailGeneratorService : IEmailGeneratorService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public EmailGeneratorService(
            BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> GenerateEmailConfirmationContentAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("templates");

            var blobClient = containerClient.GetBlobClient("index.html");

            BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync();

            using var streamReader = new StreamReader(blobDownloadInfo.Content);
            string content = await streamReader.ReadToEndAsync();

            return content;
        }
    }
}
