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
            var currencies = await _currencyService.GetAllCurrencies();
            var result = currencies.Select(x => new CurrencyResponse(x.Id, x.Code, x.FullName, x.Sign));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCurrency([FromBody]CurrencyRequest request)
        {
            var (currency, error) = Currency.Create
            (
                Guid.NewGuid(),
                request.code,
                request.fullName,
                request.sign
             );

           var currencyId = await _currencyService.CreateCurrency(currency);

           return Ok(currencyId); 
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Guid>> UpdateCurrency([FromBody] CurrencyRequest request, Guid id)
        {
            var updated = await _currencyService.Update(id, request.code, request.fullName, request.sign);

            return Ok(id);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Guid>> DeleteCurrency(Guid id)
        {
           await _currencyService.DeleteCurrency(id);
            return Ok(id);
        }

        [HttpGet("{code:alpha}")]
        public async Task<ActionResult<CurrencyResponse>> GetCurrencyByCode(string code)
        {
            var currency = await _currencyService.GetByCode(code);
            var result = new CurrencyResponse(currency.Id, currency.Code, currency.FullName, currency.Sign);

            return Ok(result);
        }
        
    }
}
