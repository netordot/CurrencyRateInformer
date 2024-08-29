using CurrencyApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyApi.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRateEntity>()
                .HasOne(e => e.BaseCurrency)
                .WithMany()
                .HasForeignKey(e => e.baseCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeRateEntity>()
                .HasOne(e => e.TargetCurrency)
                .WithMany()
                .HasForeignKey(e => e.TargetCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<CurrencyEntity> Currencies { get; set; }
        public DbSet<ExchangeRateEntity> ExchangeRates { get; set; }


    }
}
