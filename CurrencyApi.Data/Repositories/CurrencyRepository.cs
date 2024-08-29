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


       // На данном этапе метод реализован криво, в дальнейшем будет рефакторинг

       public async Task<List<Currency>> GetCurrencyByCode(string code)
        {
            
                var currencyEntities = await _context.Currencies.Where(x => x.Code == code).ToListAsync();

                var result = currencyEntities
                    .Select(x => Currency.Create(x.Id, x.Code, x.FullName, x.Sign).currency)
                    .ToList();

                return result;
            



        }

        
             
    }
}
