﻿using Disco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IEmailService
    {
        public void EmailConfirmation(EmailConfirmationModel model);
    }
}
