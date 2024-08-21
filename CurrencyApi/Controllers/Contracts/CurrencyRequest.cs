namespace CurrencyApi.Controllers.Contracts
{
    public record CurrencyRequest
    (
        string code,
        string fullName,
        string sign);
}
