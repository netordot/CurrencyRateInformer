//using CurrencyApi.Data.Entities;
using CurrencyApi.Domain.Models;

namespace CurrencyApi.Data.Repositories
{
    public interface ICurrencyRepository
    {
        Task<Guid> Create(Currency currency);
        Task<Guid> Delete(Guid id);
        Task<List<Currency>> Get();
        //TODO: добавить поиск по коду
        //Task<CurrencyEntity> GetCurrencyByCode(string code);
        Task<Guid> Update(Guid id, string code, string fullname, string sign);
    }
}