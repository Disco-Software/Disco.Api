﻿using Disco.Business.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthSchema.DEFAULT_USER_AUTHENTICATION, Roles = UserRole.ADMIN_ROLE)]
    public class AdminController : ControllerBase
    {
    }
}
