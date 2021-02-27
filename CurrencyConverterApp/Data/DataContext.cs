using Microsoft.EntityFrameworkCore;

namespace CurrencyConverterApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyQuote> CurrencyQuote { get; set; }
    }
}