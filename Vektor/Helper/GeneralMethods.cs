using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vektor.Helper
{
    public class GeneralMethods
    {
        public static string RemLetters(string myString)
        {
            string remLettersRet = default;
            string regPattern = "[a-zA-Z]+";

            var regx = new Regex(regPattern);
            remLettersRet = regx.Replace(myString, "");
            remLettersRet = Regex.Replace(remLettersRet, @"\,$", "");
            return remLettersRet;
        }
    }
}
