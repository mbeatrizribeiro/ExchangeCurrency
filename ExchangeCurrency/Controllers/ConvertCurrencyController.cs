using ExchangeCurrency.Api.Models.Enums;
using ExchangeCurrency.Api.Models.Interface;
using ExchangeCurrency.Api.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Controllers
{
    public class ConvertCurrencyController : Controller
    {
        private readonly IExchangeCurrencyService _exchangeCurrencyService;

        public ConvertCurrencyController(IExchangeCurrencyService exchangeCurrencyService)
        {
            _exchangeCurrencyService = exchangeCurrencyService;
        }


        [HttpPost("")]
        public async Task<IActionResult> Index([FromForm] CurrencyInputModel request)
        {
            var retorno = await _exchangeCurrencyService.GetExchangeCurrency(request.FromCurrency, request.ToCurrency, request.Amount, EnumProfile.Private);

            return Ok(retorno);
        }
    }
}
