using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.Friends
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int Friends { get; set; }
        public int Posts { get; set; }
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
    }
}
