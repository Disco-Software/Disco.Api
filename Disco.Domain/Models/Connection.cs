using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Models
{
    public class Connection : BaseModel<string>
    {
        public string UserAgent { get; set; }
        public bool IsConnected { get; set; }
    }
}
