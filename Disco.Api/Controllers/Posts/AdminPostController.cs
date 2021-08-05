using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Server.Controllers.Posts
{
    public class AdminPostController : Controller
    {
        private readonly ApplicationDbContext ctx;
        public AdminPostController(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

    }
}
