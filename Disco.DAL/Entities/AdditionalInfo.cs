using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class AdditionalInfo : BaseEntity.BaseEntity<int>
    {
        public string Status { get; set; }
    }
}
