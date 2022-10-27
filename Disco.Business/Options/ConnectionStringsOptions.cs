using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Options
{
    public class ConnectionStrings
    {
        public string DevelopmentConnection { get; set; }
        public string ProdactionConnection { get; set; }
        public string BlobStorage { get; set; }
        public string AzureNotificationHubConnection { get; set; }
    }
}
