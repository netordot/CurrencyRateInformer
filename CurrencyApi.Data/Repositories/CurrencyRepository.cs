using CurrencyApi.Data.Entities;
using CurrencyApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApi.Data.Repositories
{
    /// <summary>
    /// Класс содержит реализацию CRUD операций над сущностью Currency + несколько вспомогательных методов
    /// </summary>
    public class CurrencyRepository : ICurrencyRepository
    {
        private ApplicationDataContext _context;
        public CurrencyRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<List<Currency>> Get()
        {
            var currencyEntities = await _context.Currencies.AsNoTracking().ToListAsync();

            var result = currencyEntities
                .Select(x => Currency.Create(x.Id, x.Code, x.FullName, x.Sign).currency)
                .ToList();

            return result;
        }

        public async Task<Guid> Create(Currency currency)
        {
            var currencyEntity = new CurrencyEntity
            {
                Id = currency.Id,
                Code = currency.Code,
                FullName = currency.FullName,
                Sign = currency.Sign

            };

            await _context.Currencies.AddAsync(currencyEntity);
            await _context.SaveChangesAsync();

            return currencyEntity.Id;

        }

        public async Task<Guid> Update(Guid id, string code, string fullname, string sign)
        {
            await _context.Currencies
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(a => a
                .SetProperty(x => x.Code, x => code)
                .SetProperty(x => x.Sign, x => sign)
                .SetProperty(x => x.FullName, x => fullname));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context
                .Currencies
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }

       public async Task<Currency> GetCurrencyByCode(string Code)
        {
            var currencyDb = await _context.Currencies.FirstOrDefaultAsync(x => x.Code == Code);

            if (currencyDb == null)
            {
                throw new Exception("Валюта не найдена!");
            }

            var currencyToReturn = Currency.Create(currencyDb.Id, currencyDb.Code, currencyDb.FullName, currencyDb.Sign).currency;

            return currencyToReturn;
        }

        public async Task<Guid> GetCurrencyIdByCode(string code)
        {
            var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.Code == code);

            if (currency == null)
            {
                throw new ArgumentException("Валюта не существует");
            }

            return currency.Id;
        }
        
        public async Task<string> GetCodeById(Guid Id)
        {
            var currencyInDb = await _context.Currencies.FirstOrDefaultAsync(x => x.Id == Id);

            if (currencyInDb == null)
            {
                throw new Exception("Валюта не найдена!");
            }

            return currencyInDb.Code;
        }
             
    }
}
