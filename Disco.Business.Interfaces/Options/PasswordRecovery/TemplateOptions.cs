using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Options.PasswordRecovery
{
    public class TemplateOptions
    {
        public TemplateOptions() { }
        public TemplateOptions(
            string ukranianTemplate,
            string englishTemplate,
            string spanishTemplate)
        {
            UkranianTemplate = ukranianTemplate;
            EnglishTemplate = englishTemplate;
            SpanishTemplate = spanishTemplate;
        }

        public string UkranianTemplate { get; set; }
        public string EnglishTemplate { get; set; }
        public string SpanishTemplate { get; set; }
    }
}
