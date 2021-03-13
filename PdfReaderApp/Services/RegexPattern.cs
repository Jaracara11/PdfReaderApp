using System.Collections.Generic;

namespace PdfReaderApp.Services
{
    public static class RegexPattern
    {
        public static string MatchProducts = "[a-zA-Z0-9]";

        public static string MatchPrices = "0{2}";

        public static string MatchWhiteSpaces = @"\s+";

        public static string MatchNewLine = ".+";

        public static string MatchProductName = "[A-Za-z]";

        public static string MatchProductPricePorMayor = "[a-zA-Z0-9]";

        public static string MatchProductPriceAlDetalle = "[a-zA-Z0-9]";

        public static string MatchStringLenght = "[a-zA-Z0-9]{0,50}$";

        public static List<string> CharsToRemove = new List<string>()
        {
            "-", "*", "UD", "CARTON", "PAQ.", "1 LIBRA", "LB" , "GALON"
        };
    }
}

