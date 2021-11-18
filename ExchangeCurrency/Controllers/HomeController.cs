using ExchangeCurrency.Api.Models.Enums;
using ExchangeCurrency.Api.Models.Interface;
using ExchangeCurrency.Api.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ExchangeCurrency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExchangeCurrencyService _exchangeCurrencyService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Varejo()
        {
            return View();
        }  

        //[HttpPost]
        //public async Task<IActionResult> VarejoAsync([FromForm] CurrencyInputModel request)
        //{
        //    var retorno = await _exchangeCurrencyService.GetExchangeCurrency(request.FromCurrency, request.ToCurrency, request.Amount, request.Profile);

        //    return Ok(retorno);
        //}

        public IActionResult Converter()
        {
            return View();
        }

        //[HttpPost("")]
        //public async Task<IActionResult> Converter([FromForm] CurrencyInputModel request)
        //{
        //    var retorno = await _exchangeCurrencyService.GetExchangeCurrency(request.FromCurrency, request.ToCurrency, request.Amount, request.Profile);

        //    return Ok(retorno);
        //}

        public IActionResult Personnalite()
        {
            return View();
        }

        public IActionResult Private()
        {
            return View();
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        // GET api/<ConvertController>/5
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Convert([FromForm] string from, [FromForm] string to, [FromForm] decimal amount, [FromRoute] EnumProfile profile)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _exchangeCurrencyService.GetExchangeCurrency(from, to, amount, profile);
                return Ok(retorno);
            }

            return RedirectToAction();
        }

    }
}
