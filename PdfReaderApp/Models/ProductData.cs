using System.Collections.Generic;

namespace PdfReaderApp.Models
{
    public class Data
    {
        public string Nombre { get; set; }
        public decimal PrecioPorMayor { get; set; }
        public decimal PrecioAlDetalle { get; set; }
    }

    public class Product
    {
        public static List<Data> ProductObj { get; set; }
    }
}
