using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dto.Friends
{
    public class FriendResponseDto
    {
        public Domain.Models.Profile UserProfile { get; set; }
        public Domain.Models.Profile FriendProfile { get; set; }
        public int FriendId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
