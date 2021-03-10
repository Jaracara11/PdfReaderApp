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
        private string Text { get; set; }

        public string TextFromPDF()
        {
            var path = @$"c:/users/{Environment.UserName}/desktop/Precios.pdf";
            var pageContent = "";

            PdfReader pdfReader = new PdfReader(path);
            PdfDocument pdfDoc = new PdfDocument(pdfReader);

            for (var i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                pageContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i), strategy);
            }

            pdfDoc.Close();
            pdfReader.Close();

            return pageContent;
        }

        public void PdftoCsv()
        {
            var textOutput = @$"c:/users/{Environment.UserName}/desktop/Precios.txt";
            var text = TextFromPDF();
            var textArray = new string[] { };

            foreach(var t in text)
            {
                File.WriteAllText
            }


            for (var i = 0; i<textArray.Length; i++)
            {
                File.WriteAllLines(textOutput, textArray);
            }
        }
    }
}
