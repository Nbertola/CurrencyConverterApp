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

        public DbSet<Currencies> Currencies { get; set; }

        public DbSet<CurrencyQuotes> CurrencyQuotes { get; set; }
    }

}