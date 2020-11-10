using CBR_Currency.Models;
using Microsoft.EntityFrameworkCore;

namespace CBR_Currency
{
    public class DbCurrencyContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }

        private const string connectionString = @"Data Source=DESKTOP-PQ20366;Initial Catalog=CurrencyDB;Integrated Security=True;Pooling=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
