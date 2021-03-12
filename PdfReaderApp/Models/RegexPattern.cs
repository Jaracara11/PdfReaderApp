using System.Collections.Generic;

namespace PdfReaderApp.Models
{
    public static class RegexPattern
    {
        public static string MatchProducts = "[a-zA-Z0-9]";

        public static string MatchProductName = "[^0-9]";

        public static string MatchProductPricePorMayor = "[a-zA-Z0-9]";

        public static string MatchProductPriceAlDetalle = "[a-zA-Z0-9]";

        public static string MatchStringLenght = "/[a-zA-Z0-9]{0,50}$/";

        public static List<string> StringsToRemove = new List<string>()
        {
            "*", "República Dominicana",
                "MERCADOS DOMINICANOS DE ABASTO AGROPECUARIO ",
                "PRODUCTOS", "UNIDAD DE", "MEDIDA", "PRECIOS POR",
                "PRECIOS DE", "DETALLE", "MAYOR", "           ", "      "
                , "  ", "Nota: precios dereferencia, suministrados por los",
            "productores, sujetos a variación.", "MERCA SANTO DOMINGO",
            "km.22, Autopista Duarte, Avenida Merca Santo ", "CARTON",
            "Domingo, Tel: 829-541-6464", "http:/www.mercadom.gob.doMail:",
            "info@mercadom.gob.do", "-", "LB", "PAQ.", "UD", "GALON", "1 LIBRA",
            "Busca las banderitas de especiales del 8 al 10 de marzo 2021."
        };
    }
}

