using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Videos
{
    public class CreateVideoModel
    {
        public IFormFile VideoFile { get; set; }
        public int PostId { get; set; }
    }
}
