using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Interfaces.Options
{
    public class ConnectionStringsOptions
    {
        public string DevelopmentConnection { get; set; }
        public string ProdactionConnection { get; set; }
        public string BlobStorage { get; set; }
        public string AzureNotificationHubConnection { get; set; }
    }
}
