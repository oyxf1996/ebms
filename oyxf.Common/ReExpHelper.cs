using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace oyxf.Common
{
    public static class ReExpHelper
    {
        public static bool IsNumber(this string str){
            Regex reg = new Regex(@"^\d+$");
            return reg.IsMatch(str);
        }
    }
}
