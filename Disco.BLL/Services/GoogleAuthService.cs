using Disco.BLL.Interfaces;
using Disco.BLL.Models.Authentication;
using Disco.BLL.Models.Google;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public GoogleAuthService(IHttpClientFactory _httpClientFactory) 
        {
            httpClientFactory = _httpClientFactory; 
        }

        public async Task<Person> GetUserData(IGoogleAuthProvider authProvider)
        {
            var credential = await authProvider.GetCredentialAsync();

            var service = new PeopleServiceService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                ApplicationName = "Disco",
                HttpClientInitializer = credential
            });

            var response = service.People.Get("people/me").Execute();
            
            return response;
        }
    }
}
