using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Video : BaseEntity.BaseEntity<int>
    {
        public int PostId { get; set; }
        public string Source { get; set; }
    }
}
