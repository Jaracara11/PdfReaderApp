using CsvHelper;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using PdfReaderApp.Models;
using PdfReaderApp.Services;
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
            var pdfPath = Path.PdfPath;
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

        public static List<ProductData> ProductList()
        {
            var text = RegexServices.GetTextByLine(GetTextFromPdf());
            var textList = new List<string>();
            var removeChars = new List<string>(RegexPattern.CharactersToRemove);

            foreach (var line in text)
            {
                if (Regex.Match(line, RegexPattern.MatchProductText).Success &&
                    Regex.Match(line, RegexPattern.MatchPriceText).Success)
                {
                    var resultText = RegexServices.ReplaceText(line, "", RegexPattern.MatchWhiteSpaces);

                    for (var i = 0; i < removeChars.Count; i++)
                    {
                        resultText = resultText.Replace(removeChars[i], "");
                        resultText = resultText.Replace("Ñ", "NI");
                        resultText = resultText.Replace("É", "E");
                    }

                    textList.Add(resultText);
                }
            }

            return RegexServices.GetProductAndPrices(textList);
        }

        public static void WriteDataToCsv()
        {
            var textList = ProductList();
            var csvOutput = Path.CsvOutput;
            var writer = new StreamWriter(csvOutput);
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<CsvHeaders>();
            csv.NextRecord();

            foreach (var item in textList)
            {
                csv.WriteField(item.Nombre);
                csv.WriteField(item.PrecioPorMayor);
                csv.WriteField(item.PrecioAlDetalle);
                csv.NextRecord();
            }

            writer.Flush();
        }
    }
}