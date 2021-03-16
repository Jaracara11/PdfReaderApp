using PdfReaderApp.Models;
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

        public static List<ProductData> GetProductAndPrices(List<string> itemList)
        {
            var productList = new List<ProductData>();

            var rgx = new Regex(RegexPattern.MatchProductsAndPrices);

            foreach (var item in itemList)
            {
                MatchCollection matches = rgx.Matches(item);

                foreach (Match match in matches)
                {
                    productList.Add(new ProductData()
                    {
                        Nombre = match.Groups["Product"].Value,
                        PrecioPorMayor = match.Groups["PriceLot"].Value,
                        PrecioAlDetalle = match.Groups["PriceUnit"].Value
                    });
                }
            }

            return productList;
        }
    }
}
