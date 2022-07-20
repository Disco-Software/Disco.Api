using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Dto.Videos
{
    public class CreateVideoDto
    {
        public IFormFile VideoFile { get; set; }
        public int PostId { get; set; }
    }
}
