using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Managers
{
    public class FormFileManager : IFormFile
    {
        private readonly byte[] _fileContents;
        private readonly string _fileName;
        private readonly string _contentType;

        public FormFileManager(byte[] fileContents, string fileName, string contentType = "application/octet-stream")
        {
            _fileContents = fileContents;
            _fileName = fileName;
            _contentType = contentType;
        }

        public long Length => _fileContents.Length;

        public string FileName => _fileName;

        public string ContentType => _contentType;

        public string ContentDisposition => $"form-data; name=\"file\"; filename=\"{_fileName}\"";

        public string Name => "file";

        public IHeaderDictionary Headers => new HeaderDictionary();

        public void CopyTo(Stream target) => new MemoryStream(_fileContents).CopyTo(target);

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            var memoryStream = new MemoryStream(_fileContents);
            return memoryStream.CopyToAsync(target, 81920, cancellationToken);
        }

        public Stream OpenReadStream() => new MemoryStream(_fileContents);
    }
}
