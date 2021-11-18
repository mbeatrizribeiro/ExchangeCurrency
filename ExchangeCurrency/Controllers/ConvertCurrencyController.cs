using ExchangeCurrency.Api.Models;
using ExchangeCurrency.Api.Models.Enums;
using ExchangeCurrency.Api.Models.Interface;
using ExchangeCurrency.Api.Models.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Controllers
{
    public class ConvertCurrencyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IExchangeCurrencyService _exchangeCurrencyService;

        public ConvertCurrencyController(IExchangeCurrencyService exchangeCurrencyService, IMediator mediator)
        {
            _exchangeCurrencyService = exchangeCurrencyService;
            _mediator = mediator;
        }


        [HttpPost("")]
        public async Task<IActionResult> Index([FromForm] Varejo request)
        {
            CancellationToken token = default;
            var retorno = await _exchangeCurrencyService.Handle(request, token);

            return Ok(retorno);
        }
    }
}
