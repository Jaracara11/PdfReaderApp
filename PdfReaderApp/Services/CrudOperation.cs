using PdfReaderApp.Data;
using PdfReaderApp.Models;
using System;
using System.Collections.Generic;

namespace PdfReaderApp.Services
{
    public class CrudOperation
    {
        public static List<ProductData> SaveProducts()
        {
            var productList = ReaderController.ProductList();
            var productToSave = new List<ProductData>();
            var context = new ProductDbContext();

            try
            {
                foreach (var item in productList)
                {
                    productToSave.Add(new ProductData()
                    {
                        Nombre = item.Nombre,
                        PrecioPorMayor = item.PrecioPorMayor,
                        PrecioAlDetalle = item.PrecioAlDetalle
                    });
                }

                context.AddRange(productToSave);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return productToSave;
        }
    }
}
