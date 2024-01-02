using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Helpers
{
    public static class PasswordRecoveryGenerationCodeHelper
    {
        public static string GenerateRecoveryCode()
        {
            Random random = new Random();
            const int codeLength = 6;

            string recoveryCode = string.Concat(Enumerable.Range(0, codeLength)
                .Select(_ => random.Next(10).ToString()));

            return recoveryCode;
        }
    }
}
