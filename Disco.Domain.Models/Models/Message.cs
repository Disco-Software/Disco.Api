using Disco.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.Domain.Models.Models
{
    public class Message : BaseModel<int>
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
