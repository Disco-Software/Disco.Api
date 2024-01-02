using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Helpers
{
    public static class ConfirmationCodeGenerationHelper
    {
        public static int GenerateEmailConfirmationCode()
        {
            Random random = new Random();
            int generatedNumber = 0;

            for (int i = 0; i < 6; i++)
            {
                int randomDigit = random.Next(0, 10); 
                generatedNumber = generatedNumber * 10 + randomDigit;
            }

            return generatedNumber;
        }
    }
}
