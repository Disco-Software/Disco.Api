﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Ticket.User.CreateTicket
{
    public class CreateTicketRequestDto
    {
        public CreateTicketRequestDto(
            string title,
            string description,
            string status,
            string priority)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
        }

        public string Title {  get; set; }
        public string Description {  get; set; }
        public string Priority {  get; set; }
        public string Status {  get; set; }
    }
}
