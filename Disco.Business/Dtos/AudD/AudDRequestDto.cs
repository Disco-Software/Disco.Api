using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dtos.AudD
{
    public class AudDRequestDto
    {
        public string api_token { get; set; }
        public string url { get; set; }
        public string @return { get; set; }
    }
}
