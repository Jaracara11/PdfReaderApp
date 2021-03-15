using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfReaderApp
{
    public class CsvHeaders
    {
        [Index(0)]
        [Name("Productos")]
        public string Productos { get; set; }

        [Index(1)]
        [Name("PreciosAlPorMayor")]
        public decimal PreciosPorMayor { get; set; }

        [Index(2)]
        [Name("PreciosAlDetalle")]
        public decimal PreciosAlDetalle { get; set; }
    }
}
