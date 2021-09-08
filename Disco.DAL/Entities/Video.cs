using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Video : Base.BaseEntity<int>
    {
        public string VideoSource { get; set; }
    }
}
