using System;
using System.Collections.Generic;

namespace PdfReaderApp
{
    public class Options
    {
        public static string PdfPath = @$"c:/users/{Environment.UserName}/desktop/Precios.pdf";

        public static string TextOutput = @$"c:/users/{Environment.UserName}/desktop/Precios.txt";

        public static string CsvOutput = @$"c:/users/{Environment.UserName}/desktop/Precios.csv";

        public static List<string> CharsToRemove = new List<string>()
        {
            "*", "República Dominicana",
                "MERCADOS DOMINICANOS DE ABASTO AGROPECUARIO ",
                "PRODUCTOS", "UNIDAD DE", "MEDIDA", "PRECIOS POR",
                "PRECIOS DE", "DETALLE", "MAYOR", "           ", "      "
                , "  ", "Nota: precios dereferencia, suministrados por los",
            "productores, sujetos a variación.",
                "Busca las banderitas de especiales del 8 al 10 de",
            "marzo 2021.", "MERCA SANTO DOMINGO",
            "km.22, Autopista Duarte, Avenida Merca Santo ",
            "Domingo, Tel: 829-541-6464", "http:/www.mercadom.gob.doMail:",
            "info@mercadom.gob.do", "-", "LB", "PAQ.", "UD"
        };
    }
}
