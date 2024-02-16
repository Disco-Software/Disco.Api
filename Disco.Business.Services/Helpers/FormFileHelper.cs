using Disco.Business.Services.Managers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Helpers
{
    public static class FormFileHelper
    {
        public static IFormFile CreateIFormFile(byte[] fileContents, string fileName, string contentType = "application/octet-stream")
        {
            return new FormFileManager(fileContents, fileName, contentType);
        }

    }
}
