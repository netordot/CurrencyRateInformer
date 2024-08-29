using CurrencyApi.Data.Repositories;
using CurrencyApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrecyApi.Application.Sercvices
{
    public class CurrencyService : ICurrencyService
    {

        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<List<Currency>> GetAllCurrencies()
        {
            return await _currencyRepository.Get();
        }

        public async Task<Guid> CreateCurrency(Currency currency)
        {
            return await _currencyRepository.Create(currency);
        }

        public async Task<Guid> DeleteCurrency(Guid id)
        {
            return await _currencyRepository.Delete(id);
        }

        public async Task<Guid> Update(Guid id, string code, string fullname, string sign)
        {
            return await _currencyRepository.Update(id, code, fullname, sign);
        }

        public async Task<List<Currency>> GetByCode(string code)
        {
            return await _currencyRepository.GetCurrencyByCode(code);
        }

       public async Task<Guid> GetIdByCodeAsync(string Code)
        {
            return await _currencyRepository.GetCurrencyIdByCode(Code);
        }
    }
}
