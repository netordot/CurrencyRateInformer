using CurrecyApi.Application.Sercvices;
using CurrencyApi.Controllers.Contracts;
using CurrencyApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CurrencyResponse>>> GetAll()
        {
            var currencies =  await _currencyService.GetAllCurrencies();

            var result = currencies.Select(x => new CurrencyResponse(x.Id, x.Code, x.FullName, x.Sign));

            return Ok(result);
            
        }

        public async Task<ActionResult<Guid>> CreateCurrency([FromBody]CurrencyRequest request)
        {
            var (currency, error) = Currency.Create
            (
                Guid.NewGuid(),
                request.code,
                request.fullName,
                request.sign
                );

            //TODO: не хватает валидации, прописанной в Domain слое

           var currencyId = _currencyService.CreateCurrency(currency);

           return Ok(currencyId);  

            
        }

    }
}
