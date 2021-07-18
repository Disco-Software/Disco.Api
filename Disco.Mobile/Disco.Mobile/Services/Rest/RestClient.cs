using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Disco.Mobile.Services.Rest
{
    public static class RestClient
    {
        public static HttpClient GetClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://172.16.0.164:80/Disco.Server/");
            return httpClient;
        }
    }
}
