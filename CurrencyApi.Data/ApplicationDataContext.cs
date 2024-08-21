using CurrencyApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyApi.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) 
        {
            
        }

        public DbSet<CurrencyEntity> Currencies { get; set; }
        public DbSet<ExchangeRateEntity> ExchangeRates { get; set; }


    }
}
