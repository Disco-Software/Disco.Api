using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Post : BaseEntity.BaseEntity<int>
    {
        public string Description { get; set; }
        
        public Photo Photo { get; set; }
        public Video Video { get; set; }
        public Sound Sound { get; set; }
        
        //[ForeignKey("User")]
        public string UserId { get; set; }
    }
}
