using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Entities
{
    public class UserSubscriber : BaseEntity.BaseEntity<int>
    {
        public string UserId { get; set; }
        public string SubscriberId { get; set; }
    }
}
