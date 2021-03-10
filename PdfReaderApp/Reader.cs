using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfReaderApp
{
    public class Reader
    {
        public string TextFromPdf()
        {
            var path = @$"c:/users/{Environment.UserName}/desktop/Precios.pdf";
            var pageContent = "";

            try
            {
                PdfReader pdfReader = new PdfReader(path);
                PdfDocument pdfDoc = new PdfDocument(pdfReader);

                for (var i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    pageContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i), strategy);
                }

                pdfDoc.Close();
                pdfReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return pageContent;
        }

        public void PdftoCsv()
        {
            var textOutput = @$"c:/users/{Environment.UserName}/desktop/Precios.txt";
            var text = TextFromPdf();
            var preciosTxt = File.Create(textOutput);

            var textArray = text.ToArray();

            foreach (var i in textArray)
            {
                File.WriteAllLines(textOutput, i);
            }
        }
    }
}
i