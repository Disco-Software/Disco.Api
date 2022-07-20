using Disco.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Dto.Friends
{
    public class FriendResponseDto
    {
        public DAL.Models.Profile UserProfile { get; set; }
        public DAL.Models.Profile FriendProfile { get; set; }
        public int FriendId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
