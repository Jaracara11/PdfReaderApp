using Microsoft.EntityFrameworkCore;
using PdfReaderApp.Models;

namespace PdfReaderApp.Data
{
    class ProductDbContext: DbContext
    {
        public DbSet<ProductData> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Path.DataSource);
        }
    }
}
