using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Profile
{
    public class UpdateProfileModel
    {
        public IFormFile Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string Cread { get; set; }
    }
}
