using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Album : BaseEntity.BaseEntity<int>
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public List<Song> Songs { get; set; } 
        public int ExecutorId { get; set; }
    }
}
