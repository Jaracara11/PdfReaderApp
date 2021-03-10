using CsvHelper;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
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

            string[] textArray = text.Split(Environment.NewLine);

            File.WriteAllLines(textOutput, textArray);
        }
    }
}