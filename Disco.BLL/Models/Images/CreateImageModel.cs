using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Images
{
    public class CreateImageModel
    {
        public IFormFile ImageFile { get; set; }
    }
}
