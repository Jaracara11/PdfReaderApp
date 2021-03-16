using CsvHelper.Configuration.Attributes;
using System;

namespace PdfReaderApp
{
    public class CsvHeaders
    {
        [Index(0)]
        [Name("Producto")]
        public string Producto { get; set; }

        [Index(1)]
        [Name("PrecioAlPorMayor")]
        public decimal PrecioPorMayor { get; set; }

        [Index(2)]
        [Name("PrecioAlDetalle")]
        public decimal PrecioAlDetalle { get; set; }
    }
}
