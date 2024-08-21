using CurrencyApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApi.Data.Entities
{
    public class ExchangeRateEntity
    {

        public Guid Id { get; set; }
        public required CurrencyEntity BaseCurrency { get; set; }
        public required CurrencyEntity TargetCurrency { get; set; }

        public decimal Rate { get; set; }

        
    }
}
