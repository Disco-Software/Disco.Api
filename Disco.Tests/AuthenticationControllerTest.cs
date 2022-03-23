using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.BLL.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Disco.Tests.Base;
namespace Disco.Tests
{
    [TestClass]
    public class AuthenticationControllerTest : IntegrationTest
    {
        public LoginModel logInModel;
        public AuthenticationControllerTest()
        {
            httpClient.BaseAddress = new Uri("https://discoapi20211205192712.azurewebsites.net/api/");
        }
        
        [TestMethod]
        public async Task LogIn_ReturnsSuccessResponse()
        {
            logInModel = new LoginModel { Email = "stas_1999_nr@ukr.net", Password = "StasZeus2021!" };
            var json = JsonConvert.SerializeObject(logInModel);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytes = new ByteArrayContent(buffer);
            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/log-in", bytes);

            var result = await response.Content.ReadAsStringAsync();

            var userDTO = JsonConvert.DeserializeObject<UserResponseModel>(result);

            Assert.IsNotNull(userDTO);
        }

        [TestMethod]
        public async Task LogIn_ReturnsUserNotFoundResponse()
        {
            logInModel = new LoginModel { Email = "stas_1999_nr@gmail.com", Password = "StasZeus2021!" };
            var json = JsonConvert.SerializeObject(logInModel);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytes = new ByteArrayContent(buffer);
            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/log-in", bytes);

            var result = await response.Content.ReadAsStringAsync();

            var userDTO = JsonConvert.DeserializeObject<UserResponseModel>(result);

            Assert.IsTrue(userDTO.VarificationResult == "user not found");
        }

        [TestMethod]
        public async Task LogIn_ReturnsPasswordIsNotValidResponse()
        {
            logInModel = new LoginModel { Email = "stas_1999_nr@ukr.net", Password = "kds;afjlkdsajf" };
            
            var json = JsonConvert.SerializeObject(logInModel);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytes = new ByteArrayContent(buffer);
            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/log-in", bytes);

            var result = await response.Content.ReadAsStringAsync();

            var userDTO = JsonConvert.DeserializeObject<UserResponseModel>(result);

            Assert.IsTrue(userDTO.VarificationResult == "Password is not valid");
        }

        [TestMethod]
        public async Task LogIn_ReturnsNullResponse()
        {
            logInModel = new LoginModel { Email = "", Password = "" };
            var json = JsonConvert.SerializeObject(logInModel);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytes = new ByteArrayContent(buffer);
            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/log-in", bytes);

            var result = await response.Content.ReadAsStringAsync();

            var userDTO = JsonConvert.DeserializeObject<UserResponseModel>(result);

            Assert.IsTrue(userDTO.VarificationResult == "Log in form can not be a null");
        }

        [TestMethod]
        public async Task ForgotPassword_ReturnsSuccessResponse()
        {
            var model = new ForgotPasswordModel { Email = "stas_1999_nr@ukr.net" };
            var json = JsonConvert.SerializeObject(model);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytesArry = new ByteArrayContent(buffer);
            bytesArry.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/forgot-password", bytesArry);
            var result = response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject(json);

            Assert.IsNotNull(token);
        }
        
        [TestMethod]
        public async Task ForgotPassword_ReturnsErrorResponse()
        {
            var model = new ForgotPasswordModel { Email = "stas_1999_nr@ukr.net" };
            var json = JsonConvert.SerializeObject(model);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytesArry = new ByteArrayContent(buffer);
            bytesArry.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/forgot-password", bytesArry);
            var result = response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject(json);

            Assert.IsNull(token);
        }
    }
}
