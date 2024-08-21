using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApi.Domain.Models
{
    public class ExchangeRate
    {

        public ExchangeRate(Guid id, Currency baseCurrency, Currency targetCurrency, decimal rate)
        {
            Id = id;
            BaseCurrency = baseCurrency;
            TargetCurrency = targetCurrency;
            Rate = rate;
            
        }
        public Guid Id { get;  }

        [Required]
        public Currency BaseCurrency { get; }
        [Required]
        public Currency TargetCurrency { get; }

        public decimal Rate { get;  }

        public static(ExchangeRate ExRate, string Error) Create (Guid id, Currency baseCurrency, Currency targetCurrency, decimal rate)
        {
            var ExRate = new ExchangeRate(id, baseCurrency, targetCurrency, rate);

            var error = string.Empty;

            if(baseCurrency == targetCurrency)
            {
                error = "The ExchangeRate may not be created due to the same base and target currencies";
            }

            if(rate <= 0)
            {
                error = "The rate may not be less or equal than 0";
            }


            return (ExRate,  error);
        }


    }
}
