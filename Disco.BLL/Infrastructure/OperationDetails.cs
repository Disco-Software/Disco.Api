using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Infrastructure
{
    public class OperationDetails
    {
        public bool Succedeed { get; set; }
        public string Message { get; set; }
        
        public OperationDetails(bool succedeed, string message)
        {
            Succedeed = succedeed;
            Message = message;
        } 
    }
}
