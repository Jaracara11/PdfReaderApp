using CsvHelper;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PdfReaderApp
{
    public class Reader
    {
        public string TextFromPdf()
        {
            var pdfPath = @$"c:/users/{Environment.UserName}/desktop/Precios.pdf";
            var pdfContent = "";

            try
            {
                PdfReader pdfReader = new PdfReader(pdfPath);
                PdfDocument pdfDoc = new PdfDocument(pdfReader);

                for (var i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    pdfContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i), strategy);
                }

                pdfDoc.Close();
                pdfReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return pdfContent;
        }

        public void PdfToCsv()
        {
            var csvOutput = @$"c:/users/{Environment.UserName}/desktop/Precios.csv";
            var text = TextFromPdf();
            var writer = new StreamWriter(csvOutput);
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<CsvHeaders>();

            csv.WriteRecords(text);

            writer.Flush();
        }

        public void SortText()
        {
            var textOutput = @$"c:/users/{Environment.UserName}/desktop/Precios.txt";
            var text = TextFromPdf();
            var removeChars = new string[] { "*", "República Dominicana",
                "MERCADOS DOMINICANOS DE ABASTO AGROPECUARIO ",
                "PRODUCTOS", "UNIDAD DE", "MEDIDA", "PRECIOS POR",
                "PRECIOS DE", "DETALLE", "MAYOR", "           ", "      "
                ,"  ", "Nota: precios dereferencia, suministrados por los",
            "productores, sujetos a variación.",
                "Busca las banderitas de especiales del 8 al 10 de",
            "marzo 2021.", "MERCA SANTO DOMINGO", "DEL 9 DE MARZODEL 2021 (RD$)",
            "km.22, Autopista Duarte, Avenida Merca Santo ",
            "Domingo, Tel: 829-541-6464", "http:/www.mercadom.gob.doMail:",
            "info@mercadom.gob.do", "-", "LB", "PAQ.", "UD"};

            var textList = new List<string> { text };

            for (var i = 0; i < textList.Count; i++)
            {
                for (var x = 0; x < removeChars.Length; x++)
                {
                    textList[i] = textList[i].Replace(removeChars[x], "");
                }
            }

            File.WriteAllLines(textOutput, textList);
        }
    }
}