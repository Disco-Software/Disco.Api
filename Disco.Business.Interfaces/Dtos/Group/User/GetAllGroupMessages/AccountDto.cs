﻿namespace Disco.Business.Interfaces.Dtos.Group.User.GetAllGroupMessages
{
    public class AccountDto
    {
        public AccountDto(
            string photo,
            string cread,
            UserDto user)
        {
            Photo = photo;
            Cread = cread;
            User = user;
        }

        public string Photo { get; set; }
        public string Cread { get; set; }
        public UserDto User { get; set; }
    }
}