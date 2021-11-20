using ExchangeCurrency.Api.Models;
using ExchangeCurrency.Api.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeCurrency.Api.Controllers
{
    public class TaxPerProfileController : Controller
    {
        private readonly ITaxPerProfileService _taxPerProfileService;

        public TaxPerProfileController(ITaxPerProfileService taxPerProfileService)
        {
            _taxPerProfileService = taxPerProfileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("parametrizar")]
        public IActionResult Parametrizar([FromForm] ProfileRequest request)
        {
            var retorno = _taxPerProfileService.SetTax(request);
            return Ok(retorno);
        }
    }
}
