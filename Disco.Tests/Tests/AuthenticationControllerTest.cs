using Disco.Business.Dto;
using Disco.Business.Dto;
using Disco.Business.Dto.Authentication;
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
namespace Disco.Tests.Tests
{
    [TestClass]
    public class AuthenticationControllerTest : IntegrationTest
    {
        public AuthenticationControllerTest()
        {
            httpClient.BaseAddress = new Uri("https://devdiscoapi.azurewebsites.net/api/");
        }
        
        [TestMethod]
        public async Task LogIn_ReturnsSuccessResponse()
        {
            var logInModel = new LoginDto { Email = "stas_1999_nr@ukr.net", Password = "StasZeus2021!" };
            var json = JsonConvert.SerializeObject(logInModel);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytes = new ByteArrayContent(buffer);
            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/log-in", bytes);

            var result = await response.Content.ReadAsStringAsync();

            var userDTO = JsonConvert.DeserializeObject<UserResponseDto>(result);

            Assert.IsNotNull(userDTO);
        }

        [TestMethod]
        public async Task LogIn_ReturnsUserNotFoundResponse()
        {
            var loginModel = new LoginDto { Email = "stas_1999_nr@gmail.com", Password = "StasZeus2021!" };
            var json = JsonConvert.SerializeObject(loginModel);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytes = new ByteArrayContent(buffer);
            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/log-in", bytes);

            var result = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(result == "user not found");
        }

        [TestMethod]
        public async Task LogIn_ReturnsPasswordIsNotValidResponse()
        {
            var logInModel = new LoginDto { Email = "stas_1999_nr@ukr.net", Password = "kds;afjlkdsajf" };
            
            var json = JsonConvert.SerializeObject(logInModel);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytes = new ByteArrayContent(buffer);
            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/log-in", bytes);

            var result = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(result == "Password is not valid");
        }

        [TestMethod]
        public async Task LogIn_ReturnsNullResponse()
        {
            var logInModel = new LoginDto { Email = "", Password = "" };
            var json = JsonConvert.SerializeObject(logInModel);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytes = new ByteArrayContent(buffer);
            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("user/authentication/log-in", bytes);

            var result = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(result == "Log in form can not be a null");
        }

        [TestMethod]
        public async Task ForgotPassword_ReturnsSuccessResponse()
        {
            var model = new ForgotPasswordDto { Email = "stas_1999_nr@ukr.net" };
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
            var model = new ForgotPasswordDto { Email = "stas_1999_nr" };
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
