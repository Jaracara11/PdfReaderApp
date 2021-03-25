using Microsoft.EntityFrameworkCore;
using PdfReaderApp.Models;

namespace PdfReaderApp.Data
{
    class ProductDbContext: DbContext
    {
        public DbSet<ProductData> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\u29230\Source\Repos\PdfReaderApp\PdfReaderApp\Data\ProductDB.db;");
        }
    }
}
