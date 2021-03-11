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
    public class Reader
    {
        public static string GetTextFromPdf()
        {
            var pdfPath = Options.PdfPath;
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
            var removeChars = new List<string>(Options.CharsToRemove);
            var textOutput = Options.PdfOutput;

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
            var lines = File.ReadAllLines(Options.PdfOutput);

            try
            {
                foreach (var line in lines)
                {
                    if (Regex.Match(line, Options.RegexMatchProduct).Success)
                    {
                        textList.Add(line);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return textList;
        }

        public static void WriteDataToCsv()
        {
            var textList = ArrangeText();
            var csvOutput = Options.CsvOutput;
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