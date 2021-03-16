using System.Collections.Generic;

namespace PdfReaderApp.Services
{
    public static class RegexPattern
    {
        public static string MatchProductText = "[a-zA-Z0-9]";

        public static string MatchPriceText = "0{2}";

        public static string MatchWhiteSpaces = @"\s+";

        public static string MatchNewLine = ".+";

        public static string MatchProductsAndPrices = @"(?<Product>\D+)(?<PriceLot>\d+\.\d{2})(?<PriceUnit>\d+\.\d{2})";

        public static List<string> CharactersToRemove = new List<string>()
        {
            "-", "*", "UD", "CARTON", "PAQ.", "1 LIBRA", "LB" , "GALON"
        };
    }
}

