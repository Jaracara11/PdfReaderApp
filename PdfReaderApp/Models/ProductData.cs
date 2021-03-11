using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PdfReaderApp.Models
{
    public class ProductData
    {
        public string Nombre { get; set; }
        [Range(0,99999.99)]
        public decimal PrecioPorMayor { get; set; }
        [Range(0, 99999.99)]
        public decimal PrecioAlDetalle { get; set; }
    }
}
