using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CurrencyConverterApp.Data
{


    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Currency> Currency { get; set; }

        public DbSet<CurrencyQuote> CurrencyQuote { get; set; }
    }

}