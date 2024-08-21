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
    public class CurrencyConfiguration : IEntityTypeConfiguration<CurrencyEntity>
    {
        public void Configure(EntityTypeBuilder<CurrencyEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.Code).IsRequired();

            builder.Property(e => e.Sign).IsRequired();

            builder.Property(e => e.FullName).IsRequired();

            builder.Property( e=> e.Id).IsRequired();   

             //builder.(
             //typeof(CurrencyEntity).GetConstructor(new[] { typeof(Guid), typeof(string), typeof(string), typeof(string) }),
             //new[] { "Id", "Code", "FullName", "Sign" });



        }

    }
}
