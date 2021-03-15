using Disco.BLL.DTO;
using Disco.BLL.Services;
using Disco.DAL.EF;
using Disco.DAL.Identity;
using Disco.Server.Controllers;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Disco.Test
{
    public class AccountController__Test
    {
        private ApplicationDbContext ctx;
        private ApplicationUserManager manager;
        public AccountController__Test(ApplicationUserManager manager, ApplicationDbContext ctx)
        {
            manager = this.manager;
            ctx = this.ctx;
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Login_Test_ReturnsSuccess()
        {
            LoginDTO dto = new LoginDTO { Email = "stas_1999_nr@ukr.net", Password = "12345" };
            UserService service = new UserService(manager, ctx);
            await service.Login(dto);
        }

        [Test]
        public async Task Login_Test_ReturnFaild()
        {
            LoginDTO dto = new LoginDTO { Email = "ffff@gmail.com", Password = "54321" };
            UserService service = new UserService(manager, ctx);
            await service.Login(dto);
        }



    }
}