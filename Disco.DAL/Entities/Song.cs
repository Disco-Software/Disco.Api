using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class Song : BaseEntity.BaseEntity<int>
    {
        public string AudioSource { get; set; }
        public string LogoSource { get; set; }
        public string AudioName { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
