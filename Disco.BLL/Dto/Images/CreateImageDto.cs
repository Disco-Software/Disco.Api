using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Dto.Images
{
    public class CreateImageDto
    {
        public IFormFile ImageFile { get; set; }
    }
}
