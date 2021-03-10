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
        [Name("Unidad Medida")]
        public string UnidadMedida1 { get; set; }

        [Index(2)]
        [Name("PreciosAlPorMayor")]
        public decimal PreciosPorMayor { get; set; }

        [Index(3)]
        [Name("Unidad Medida")]
        public string UnidadMedida2 { get; set; }

        [Index(4)]
        [Name("PreciosAlDetalle")]
        public decimal PreciosAlDetalle { get; set; }
    }
}
