using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dto.Images
{
    public class CreateImageDto
    {
        public IFormFile ImageFile { get; set; }
    }
}
