﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PdfReaderApp.Models
{
    public class ProductData
    {
        public string Nombre { get; set; }
        public string PrecioPorMayor { get; set; }
        public string PrecioAlDetalle { get; set; }
    }
}
