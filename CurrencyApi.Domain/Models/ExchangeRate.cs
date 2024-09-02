using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApi.Domain.Models
{
    public class ExchangeRate
    {

        private ExchangeRate(Guid id, Guid baseCurrency, Guid targetCurrency, decimal rate)
        {
            Id = id;
            baseCurrencyId = baseCurrency;
            targetCurrencyID = targetCurrency;
            Rate = rate;
            
        }
        public Guid Id { get;  }

        public Currency BaseCurrency { get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid baseCurrencyId { get; }
        public Currency TargetCurrency { get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid targetCurrencyID { get; }
        public decimal Rate { get;  }

        public static(ExchangeRate ExRate, string Error) Create (Guid id, Guid baseCurrencyId, Guid targetCurrencyId, decimal rate)
        {
            var ExRate = new ExchangeRate(id, baseCurrencyId, targetCurrencyId, rate);

            var error = string.Empty;

            if(baseCurrencyId == targetCurrencyId)
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
