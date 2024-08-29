using CurrencyApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApi.Data.Entities
{
    public class ExchangeRateEntity
    {

        public Guid Id { get; set; }
        public  CurrencyEntity BaseCurrency { get; set; }

        [ForeignKey("baseCurrencyId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid baseCurrencyId { get; set; } 
        public  CurrencyEntity TargetCurrency { get; set; }
        [ForeignKey("TargetCurrencyId")]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid TargetCurrencyId { get; set; }

        public decimal Rate { get; set; }




    }
}
