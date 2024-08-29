using CurrencyApi.Domain.Models;

namespace CurrencyApi.Data.Repositories
{
    public interface ICurrencyRepository
    {
        Task<Guid> Create(Currency currency);
        Task<Guid> Delete(Guid id);
        Task<List<Currency>> Get();
       
        Task<List<Currency>> GetCurrencyByCode(string code);

        Task<Guid> Update(Guid id, string code, string fullname, string sign);

    }
}