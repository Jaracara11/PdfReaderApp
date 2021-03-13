using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PdfReaderApp.Services
{
    class RegexServices
    {
        public static string ReplaceText(string oldText, string newText, string pattern)
        {
            var rgx = new Regex(pattern);
            var result = rgx.Replace(oldText, newText);

            return result;
        }

        public static List<string> GetTextByLine(string text)
        {
            var result = new List<string>();

            foreach (Match match in Regex.Matches(text, RegexPattern.MatchNewLine))
            {
                result.Add(match.ToString());
            }

            return result;
        }

        public static string GetProductName(string product)
        {
            var productName = "";

            foreach (Match match in Regex.Matches(product, RegexPattern.MatchProductName))
            {
                productName = match.ToString();
            }

            return productName;
        }
    }
}
