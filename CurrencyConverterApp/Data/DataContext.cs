using Microsoft.EntityFrameworkCore;

namespace CurrencyConverterApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Currency> Currency { get; set; } ///El nombre de la propiedad suele ponerse en plural, siguiendo la convención de nombramiento de tablas de sql 'Currencies'
        public DbSet<CurrencyQuote> CurrencyQuote { get; set; } /// idem
    }
}