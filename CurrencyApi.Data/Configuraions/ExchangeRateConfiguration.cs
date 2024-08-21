using CurrencyApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApi.Domain.Configuraions
{
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRateEntity>
    {
        public void Configure(EntityTypeBuilder<ExchangeRateEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.BaseCurrency).IsRequired();
            builder.Property(e=>e.TargetCurrency).IsRequired();

            builder.Property(e => e.Rate).IsRequired();

               
        }
    }
}
