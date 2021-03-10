using System;

namespace PdfReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader pdf = new Reader();

            pdf.PdftoCsv();
        }
    }
}
