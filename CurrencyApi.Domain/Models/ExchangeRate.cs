using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApi.Domain.Models
{
    public class ExchangeRate
    {

        public ExchangeRate(int id, int baseCurrencyId, int targetCurrencyId, decimal rate)
        {
            Id = id;
            BaseCurrencyId = baseCurrencyId;
            TargetCurrencyId = targetCurrencyId;
            Rate = rate;
            
        }
        public int Id { get; set; }

        public int BaseCurrencyId { get; set; }

        public int TargetCurrencyId { get; set; }

        public decimal Rate { get; set; }

        public static(ExchangeRate ExRate, string Error) Create (int id, int baseCurrencyId, int targetCurrencyId, decimal rate)
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
