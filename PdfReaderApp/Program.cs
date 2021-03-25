using PdfReaderApp.Services;

namespace PdfReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ReaderController.WriteDataToCsv();
            CrudOperation.SaveProducts();
        }
    }
}
