using CsvHelper;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace PdfReaderApp
{
    public class ReaderController
    {
        public static string GetTextFromPdf()
        {
            var pdfPath = RegexPattern.PdfPath;
            var pdfContent = "";

            PdfReader pdfReader = new(pdfPath);
            PdfDocument pdfDoc = new(pdfReader);

            try
            {
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

        public static void SaveTextFromPdf()
        {
            var text = GetTextFromPdf();
            var textList = new List<string> { text };
            var removeChars = new List<string>(RegexPattern.CharsToRemove);
            var textOutput = RegexPattern.TextOutput;

            try
            {
                for (var i = 0; i < textList.Count; i++)
                {
                    for (var x = 0; x < removeChars.Count; x++)
                    {
                        textList[i] = textList[i].Replace(removeChars[x], "");
                    }
                }

                File.WriteAllLines(textOutput, textList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<string> ArrangeText()
        {
            SaveTextFromPdf();
            var textList = new List<string>();
            var lines = File.ReadAllLines(RegexPattern.TextOutput);

            try
            {
                foreach (var line in lines)
                {
                    if (Regex.Match(line, RegexPattern.RegexMatchProduct).Success)
                    {
<<<<<<< HEAD:PdfReaderApp/Reader.cs
                        textList.Add(line);
=======
                        var resultText = RegexReplaceText(line, " ", RegexPattern.MatchWhiteSpaces);

                        for (var i = 0; i < removeChars.Count; i++)
                        {
                            resultText = resultText.Replace(removeChars[i], "");
                        }

                        textList.Add(resultText);
>>>>>>> 735e78e (Push a master):PdfReaderApp/Controller/ReaderController.cs
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return textList;
        }

<<<<<<< HEAD:PdfReaderApp/Reader.cs
=======
        public static void RegexEditor()
        {
            List<ProductData> productList = new List<ProductData>();

            var products = ArrangeText();

            foreach (var product in products)
            {
                Match m;

                if (Regex.Match(product, RegexPattern.MatchProducts).Success)
                {
                    productList.Add(new ProductData() { Nombre = $"{product}" });
                }
            }

            //productList.Add(new ProductData() { Nombre = "Apio", PrecioPorMayor = 10, PrecioAlDetalle = 13});

            Console.WriteLine(productList);
        }

>>>>>>> 735e78e (Push a master):PdfReaderApp/Controller/ReaderController.cs
        public static void WriteDataToCsv()
        {
            var textList = ArrangeText();
            var csvOutput = RegexPattern.CsvOutput;
            var writer = new StreamWriter(csvOutput);
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            //csv.WriteHeader<CsvHeaders>();

            foreach (var item in textList)
            {
                csv.WriteField(item);
                csv.NextRecord();
            }

            writer.Flush();
        }
    }
}