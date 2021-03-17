using Disco.DAL.EF;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Server.Controllers
{
    public class AlbumController : Controller
    {
        private ApplicationDbContext ctx;
        public AlbumController(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        [Route("searchAL")]
        public async Task<IActionResult> GetAlbums(string name)
        {
            AlbomRepository albomRepository = new AlbomRepository(ctx);
            var album = await albomRepository.GetAll(a => a.Name.ToLower().StartsWith(name.ToLower()));
            return new JsonResult(album);
        }
    }
}
