using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Disco.Business.Interfaces.Options.PasswordRecovery;
using Disco.Business.Utils.Guards;

namespace Disco.Business.Services.Services
{
    public class PasswordRecoveryGeneratorService : IPasswordRecoveryGeneratorService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IOptions<PasswordRecoveryOptions> _passwordRecoveryOptions;

        public PasswordRecoveryGeneratorService(
            BlobServiceClient blobServiceClient,
            IHttpContextAccessor contextAccessor,
            IOptions<PasswordRecoveryOptions> passwordRecoveryOptions)
        {
            _blobServiceClient = blobServiceClient;
            _contextAccessor = contextAccessor;
            _passwordRecoveryOptions = passwordRecoveryOptions;

            DefaultGuard.ArgumentNull(_blobServiceClient);
            DefaultGuard.ArgumentNull(_contextAccessor);
            DefaultGuard.ArgumentNull(_passwordRecoveryOptions);
        }

        public async Task<string> GetPasswordRecoveryAsync()
        {
            string html = string.Empty;
            var language = _contextAccessor.HttpContext!.Request.Headers["language"];
           
            var containerClient = _blobServiceClient.GetBlobContainerClient("templates");
            
            BlobClient blobClient;         
            if (language.Contains("en"))
            {
                blobClient = containerClient.GetBlobClient(_passwordRecoveryOptions.Value.Templates.UkranianTemplate);
            }
            else if (language.Contains("uk"))
            {
                blobClient = containerClient.GetBlobClient(_passwordRecoveryOptions.Value.Templates.EnglishTemplate);
            }
            else if (language.Contains("es"))
            {
                blobClient = containerClient.GetBlobClient(_passwordRecoveryOptions.Value.Templates.SpanishTemplate);
            }
            else
            {
                blobClient = containerClient.GetBlobClient(_passwordRecoveryOptions.Value.Templates.EnglishTemplate);
            }


            BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync();

            using var streamReader = new StreamReader(blobDownloadInfo.Content);
            var htmlContent = await streamReader.ReadToEndAsync();

            html = htmlContent;

            return html;
        }
    }
}