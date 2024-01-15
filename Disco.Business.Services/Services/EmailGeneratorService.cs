using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Disco.Business.Utils.Guards;
using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Interfaces
{
    public class EmailGeneratorService : IEmailGeneratorService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public EmailGeneratorService(
            BlobServiceClient blobServiceClient,
            IHttpContextAccessor contextAccessor)
        {
            _blobServiceClient = blobServiceClient;
            _contextAccessor = contextAccessor;

            DefaultGuard.ArgumentNull(_blobServiceClient);
            DefaultGuard.ArgumentNull(_contextAccessor);
        }

        public async Task<string> GenerateEmailConfirmationContentAsync()
        {
            string html = string.Empty;
            var language = _contextAccessor.HttpContext!.Request.Headers["language"];
            var containerClient = _blobServiceClient.GetBlobContainerClient("templates");

            BlobClient blobClient;
            if(language.Contains("en"))
            {
                blobClient = containerClient.GetBlobClient("confirmation_email_en.html");
            }
            else if (language.Contains("uk"))
            {
                blobClient = containerClient.GetBlobClient("confirmation_email_uk.html");
            }
            else if (language.Contains("es"))
            {
                blobClient = containerClient.GetBlobClient("confirmation_email_es.html");
            }
            else
            {
                blobClient = containerClient.GetBlobClient("confirmation_email_en.html");
            }


            BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync();

            using var streamReader = new StreamReader(blobDownloadInfo.Content);
            string content = await streamReader.ReadToEndAsync();

            return content;
        }
    }
}
