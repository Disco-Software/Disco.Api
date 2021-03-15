using Disco.BLL.DTO;
using Disco.BLL.Services;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Disco.Server.Controllers;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Disco.Tests
{
    public class AccountController__Test
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext ctx;
        
        public AccountController__Test(ApplicationDbContext ctx, ApplicationUserManager manager)
        {
            this.ctx = ctx;
            this.userManager = manager;
        }
        public AccountController__Test()
        {

        }
        [SetUp]
        public void Setup()
        {

        }

        #region Login Testing
        /// <summary>
        /// Положительный результат
        /// </summary>
        [Test]
        public void LoginSuccessUserReturned()
        {
            LoginDTO user = new LoginDTO
            {
                Email = "stas_1999_nr@ukr.net",
                Password = "cJM23H87"
            };

            UserService service = new UserService(userManager, ctx);
            var result = service.Login(user).IsCompleted;

            Assert.IsTrue(result);
        }

        /// <summary>
        ///Возвращает неготивный результат
        /// </summary>
        [Test]
        public void LoginFaildUserReturned()
        {
            LoginDTO user = new LoginDTO
            {
                Email = "stas_1999_nr@gmail.com",
                Password = "123321"
            };
            UserService service = new UserService(userManager, ctx);
            var result = service.Login(user).IsCompletedSuccessfully;

            Assert.IsFalse(result);
        }
        /// <summary>
        /// Тестировка правельного паролья
        /// </summary>
        [Test]
        public void LoginFaildWithResultPasswordNotValidReturned()
        {
            LoginDTO dto = new LoginDTO
            {
                Email = "stas_1999_nr@ukr.net",
                Password = "1234567"
            };
            UserService service = new UserService(userManager, ctx);
            var result = service.Login(dto).IsFaulted;
            Assert.IsTrue(result);
        }

        #endregion

        #region Register Testing
        [Test]
        public void RegisterSuccessReturned()
        {
            RegisterDTO register = new RegisterDTO
            {
                FirstName = "vasya",
                UserName = "Vasya.p.p",
                Email = "pupkin.v@gmail.com",
                Password = "12345",
                ConfirmPassword = "12345"
            };

            UserService service = new UserService(userManager, ctx);
            var result = service.Register(register).IsCompleted;

            Assert.IsTrue(result);
        }
       
        [Test]
        public void RegisterFaildReturned()
        {
            RegisterDTO dto = new RegisterDTO
            {
                FirstName = "Test",
                UserName = "Test",
                Email = "Test@gmail.com",
                Password = "12345",
                ConfirmPassword = "12345"
            };
            UserService service = new UserService(userManager, ctx);
            var result = service.Register(dto).IsCompletedSuccessfully;
            Assert.IsFalse(result, "User allready created");
        }
        #endregion
    }
}