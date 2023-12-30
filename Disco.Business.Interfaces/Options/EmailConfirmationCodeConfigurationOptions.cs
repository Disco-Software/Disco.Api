using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Options
{
    public class EmailConfirmationCodeConfigurationOptions
    {
        public EmailConfirmationCodeConfigurationOptions() { }
        public EmailConfirmationCodeConfigurationOptions(int lifeTime)
        {
            LifeTime = lifeTime;
        }

        public int LifeTime { get; set; }
    }
}
