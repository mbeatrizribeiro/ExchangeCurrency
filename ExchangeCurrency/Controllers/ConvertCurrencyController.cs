using ExchangeCurrency.Api.Models.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Controllers
{
    public class ConvertCurrencyController : Controller
    {
        private readonly IMediator _mediator;

        public ConvertCurrencyController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("")]
        public async Task<IActionResult> Index([FromForm] ExchangeCurrencyRequest request)
        {
            var retorno = await _mediator.Send(request);

            Ok(retorno);

            ViewBag.Retorno = retorno.Resultado.ToString();

            return View();
        }

    }
}
