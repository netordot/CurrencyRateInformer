using CurrencyApi.Domain.Models;

namespace CurrecyApi.Application.Sercvices
{
    public interface ICurrencyService
    {
        Task<Guid> CreateCurrency(Currency currency);
        Task<Guid> DeleteCurrency(Guid id);
        Task<List<Currency>> GetAllCurrencies();
        Task<Guid> Update(Guid id, string code, string fullname, string sign);
        Task<List<Currency>> GetByCode(string code);
        Task<Guid> GetIdByCodeAsync(string Code);

    }
}