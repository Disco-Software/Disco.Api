using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Album : BaseEntity.BaseEntity<int>
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public List<Song> Songs { get; set; } 
        [ForeignKey("Executor")]
        public int ExecutorId { get; set; }
        public Executor Executor { get; set; }
    }
}
