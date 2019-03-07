using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBusTutorialERPService
{
    public static class StringExtension
    {
        public static bool In(this string str, params string[] ar)
        {
            return ar.Any(el => el.Equals(str));
        }
    }
}
