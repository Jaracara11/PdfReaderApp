using System;

namespace PdfReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader pdf = new Reader();

            Console.WriteLine(pdf.PdftoCsv()); 
        }
    }
}
