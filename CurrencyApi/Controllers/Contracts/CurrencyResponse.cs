using System.Security.Cryptography.X509Certificates;

namespace CurrencyApi.Controllers.Contracts
{
    public record CurrencyResponse(
        Guid id,
        string code,
        string fullName,
        string sign);
}