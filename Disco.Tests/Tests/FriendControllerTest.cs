using Disco.Business.Dto.Friends;
using Disco.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Tests.Tests
{
    [TestClass]
    public class FriendControllerTest : IntegrationTest
    {
        public FriendControllerTest()
        {
            httpClient.BaseAddress = new Uri("https://devdiscoapi.azurewebsites.net/api/");
        }

        [TestMethod]
        public async Task AddFriend_ReturnsSuccessResponse()
        {
            CreateFriendDto model = new CreateFriendDto { FriendId = 2 };

            var json = JsonConvert.SerializeObject(model);
            var buffer = Encoding.UTF8.GetBytes(json);

            var bytes = new ByteArrayContent(buffer);
            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJuYmYiOjE2NTU4OTMyNzMsImV4cCI6MTY1NTk2NTI3MywiaXNzIjoiZGlzY28tYXBpIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdC9EaXNjby5BcGkifQ.wuOUvhJZqOqJR0cDdLZARjkXi77BoZ4N7ou9P9988kE");
            
            var response = await httpClient.PostAsync("user/friends/create", bytes);
            var result = await response.Content.ReadAsStringAsync();

            var jsonResponse = JsonConvert.DeserializeObject<FriendResponseDto>(result);

            Assert.AreEqual(jsonResponse.FriendId, model.FriendId);
        }
        [TestMethod]
        public async Task AddFriend_ReturnsErrorResponse()
        {
            var model = new CreateFriendDto { FriendId = 2 };
        }
    }
}
