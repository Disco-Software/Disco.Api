using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services.Helpers
{
    public static class LinkHelper
    {
        public static string GetFileNameFromUrl(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                return Path.GetFileName(uri.LocalPath);
            }

            return string.Empty;
        }

    }
}
